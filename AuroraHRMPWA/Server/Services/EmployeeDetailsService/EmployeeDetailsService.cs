using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
namespace AuroraHRMPWA.Server.Services.EmployeeDetailsService
{
    public class EmployeeDetailsService : IEmployeeDetailsService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeeDetailsService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        public string GetUserEmail() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        
        public async Task<ServiceResponse<List<BankAccount>>> GetBankAccountsAsync(int userId)
        {
            var response = new ServiceResponse<List<BankAccount>>
            {
                Data = await _context.BankAccounts
                        .Where(p => p.UserId == userId)
                        .ToListAsync()
            };
            if (response.Data.Count == 0)
            {
                response.Success = false;
                response.Message = "Could not find any bank accounts for the user.";
            }

            return response;
        }

        public async Task<ServiceResponse<List<EmployeeExperience>>> GetEmployeeExperiencesAsync(int userId)
        {
            var response = new ServiceResponse<List<EmployeeExperience>>
            {
                Data = await _context.EmployeeExperiences
            .Where(p => p.UserId == userId)
            .ToListAsync()
            };
            if (response.Data.Count == 0)
            {
                response.Success = false;
                response.Message = "Could not find any previous experience for the user.";
            }

            return response;
        }

        public async Task<ServiceResponse<EmploymentDetail>> GetEmploymentDetailsAsync(int userId)
        {
            var response = new ServiceResponse<EmploymentDetail>
            {
                Data = await _context.EmploymentDetails
                    .Where(p => p.UserId == userId)
                    .FirstOrDefaultAsync()
            };
            if (response.Data == null)
            {
                response.Success = false;
                response.Message = "Could not find any employment details for the user.";
            }

            return response;
        }

        public async Task<ServiceResponse<List<FamilyMember>>> GetFamilyMembersAsync(int userId)
        {
            var response = new ServiceResponse<List<FamilyMember>>
            {
                Data = await _context.FamilyMembers
            .Where(p => p.UserId == userId)
            .ToListAsync()
            };
            if (response.Data.Count == 0)
            {
                response.Success = false;
                response.Message = "Could not find any family members for the user.";
            }

            return response;
        }

        public async Task<ServiceResponse<List<Qualification>>> GetQualificationsAsync(int userId)
        {
            var response = new ServiceResponse<List<Qualification>>
            {
                Data = await _context.Qualifications
            .Where(p => p.UserId == userId)
            .ToListAsync()
            };
            if (response.Data.Count == 0)
            {
                response.Success = false;
                response.Message = "Could not find any qualification for the user.";
            }
            return response;
        }

        public async Task<ServiceResponse<User>> GetUserAsync(int userId)
        {
            //userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            //var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            //var userstr = state.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //int userId = int.Parse(userstr);
            var response = new ServiceResponse<User>();

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                response.Success = false;
                response.Message = "Could not find the user. :(";
            }
            else
            {
                response.Data = user;
            }

            return response;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}
