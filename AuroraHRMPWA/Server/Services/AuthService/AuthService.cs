
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuroraHRMPWA.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpcontext;

        public AuthService(DataContext context, IConfiguration configuration, IHttpContextAccessor httpcontext)
        {
            _context = context;
            _configuration = configuration;
            _httpcontext = httpcontext;
        }

        public async Task<ServiceResponse<string>> Login(string email, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _context.Users.FirstOrDefaultAsync(
                x => x.Email.ToLower().Equals(email.ToLower()));

            if (user == null)
            {
                response.Success = false;
                response.Message = "No user was found.";
            }
            else if (!verifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Data = CreateToken(user);
            }

            return response;
        }


        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if (await UserExists(user.Email))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User with the same email already exists."
                };
            }

            //out is used so that we can get values and set to the user.PasswordHash and user.PasswordSalt
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = user.Id,
                Message = "New user has been added successfully."
            };
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users
                .AnyAsync(user => user.Email.ToLower()
                .Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //hmacsha512 algorithm for encrypting password
            //Giving our pass inside the algorithm,
            //Algorithm instance creates a key which can be used for Password Salt
            //The computeHash method will use the password and the key to create the pass hash
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        //Token for login
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                //Storing role for future implementation of Rolebased navigation
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public string BaseUrl()
        {
            var request = _httpcontext.HttpContext.Request;

            // Creating base URL.
            string baseURL = $"{request.Scheme}://{request.Host}{request.PathBase}";
            return baseURL;
        }

        public async Task<ServiceResponse<string>> ForgotPassword(string email)
        {
            var response = new ServiceResponse<string>();
            //Fetching user from database
            var user = await _context.Users.FirstOrDefaultAsync(
                x => x.Email.ToLower().Equals(email.ToLower()));

            if (user == null)
            {
                response.Success = false;
                response.Message = "No user was found.";
            }
            else
            {   //Generating token
                var token = CreateToken(user);
                //Getting rid of special characters
                var encodedToken = System.Text.Encoding.UTF8.GetBytes(token);
                var validToken = WebEncoders.Base64UrlEncode(encodedToken);
                //Generating Base URL
                string baseURL = BaseUrl();
                //Creating URL for resetting password
                string resetpassURL = $"{baseURL}/ResetPassword?email={email}&token={validToken}";

                var checkTokenExistence = await _context.TokenStorages.FirstOrDefaultAsync(
                    x => x.Email.ToLower().Equals(email.ToLower()));
                if (checkTokenExistence == null)
                {
                    _context.TokenStorages.Add(new TokenStorage
                    {
                        Email = email,
                        Token = validToken
                    });
                    await _context.SaveChangesAsync();
                    response.Data = resetpassURL;
                    response.Success = true;
                    response.Message = "A reset link has been sent to your email.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "A link has already been sent to your email.";
                }
            }
            return response;
        }

        public async Task<ServiceResponse<string>> ResetPassword(string email, string token, string password)
        {
            var response = new ServiceResponse<string>();
            var tokenExistence = await _context.TokenStorages.FirstOrDefaultAsync(
                x => x.Email.ToLower().Equals(email.ToLower()));
            if (tokenExistence == null)
            {
                response.Success = false;
                response.Message = "Invalid reset link.";
            }
            else
            {
                if (tokenExistence.Token.Equals(token))
                {
                    //reset password

                    //Creating password hash
                    CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                    //change password
                    await ChangePassword(email, passwordHash, passwordSalt);

                    //Delete token from storage
                    _context.TokenStorages.Remove(tokenExistence);
                    await _context.SaveChangesAsync();

                    response.Success = true;
                    response.Message = "Password has been reset successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Invalid reset link.";
                }
            }
            return response;
        }

        public async Task ChangePassword(string email, byte[] passwordHash, byte[] passwordSalt)
        {
            var user = await _context.Users.FirstOrDefaultAsync(
                x => x.Email.ToLower().Equals(email.ToLower()));
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<ServiceResponse<bool>> SendMail(string email, string mailbody)
        {
            var response = new ServiceResponse<bool>();
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("");
                    mailMessage.To.Add(email);
                    mailMessage.Subject = "Reset your password | Aurora HRM";
                    mailMessage.Body =
                    $"<h1>You have requested to reset your password.</h1> <br> <p>Click the link below:</p> <small>{mailbody}</small>";
                    mailMessage.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential("", "");
                        smtp.EnableSsl = true;
                        smtp.Send(mailMessage);
                        response.Success = true;
                        response.Data = true;
                        response.Message = "Mail sent successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
