using Microsoft.AspNetCore.Mvc;

namespace AuroraHRMPWA.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly IEmployeeDetailsService _employeeDetailsService;

        public EmployeeDetailsController(IEmployeeDetailsService employeeDetailsService)
        {
            _employeeDetailsService = employeeDetailsService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<User>>> GetUser(int userId)
        {
            var result = await _employeeDetailsService.GetUserAsync(userId);
            return Ok(result);
        }
    }
}
