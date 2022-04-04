using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuroraHRMPWA.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly IEmployeeDetailsService _employeeDetailsService;
        //private readonly IHttpContextAccessor _contextAccessor;

        public EmployeeDetailsController(IEmployeeDetailsService employeeDetailsService, IHttpContextAccessor contextAccessor)
        {
            _employeeDetailsService = employeeDetailsService;
            //_contextAccessor = contextAccessor;
        }

        [HttpGet("getuser/{userId}")]
        public async Task<ActionResult<ServiceResponse<User>>> GetUser(int userId) 
        {
            //string? id = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (id == null)
            //{
            //   return BadRequest("ki hoilo");
            //}
            var result = await _employeeDetailsService.GetUserAsync(userId);
            return Ok(result);
        }
    }
}
