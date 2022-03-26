using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuroraHRMPWA.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        //Injecting auth service
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegister request)
        {
            if (request.Title == null)
            {
                request.Title = "";
            }
            var response = await _authService.Register(
                new User
                {
                    Email = request.Email,
                    Title = request.Title,
                    Name = request.Name,
                    Nationality = request.Nationality,
                    Passport = request.Passport,
                    MaritalStatus = request.MaritalStatus,
                    Gender = request.Gender,
                    Address = request.Address,
                    PostCode = request.PostCode,
                    State = request.State,
                    Phone = request.Phone,
                    BirthDate = request.BirthDate,
                    Role = request.Role,


                }, request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
