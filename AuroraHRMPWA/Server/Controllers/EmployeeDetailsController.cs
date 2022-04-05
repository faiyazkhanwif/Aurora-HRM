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

        [HttpGet("getemploymentdetails/{userId}")]
        public async Task<ActionResult<ServiceResponse<EmploymentDetail>>> GetEmploymentDetails(int userId)
        {
            var result = await _employeeDetailsService.GetEmploymentDetailsAsync(userId);
            return Ok(result);
        }

        [HttpGet("getbankaccounts/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<BankAccount>>>> GetBankAccounts(int userId)
        {
            var result = await _employeeDetailsService.GetBankAccountsAsync(userId);
            return Ok(result);
        }

        [HttpGet("getemployeeexperiences/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<EmployeeExperience>>>> GetEmployeeExperiences(int userId)
        {
            var result = await _employeeDetailsService.GetEmployeeExperiencesAsync(userId);
            return Ok(result);
        }

        [HttpGet("getqualifications/{userId}")]
        public async Task<ActionResult<ServiceResponse<List<Qualification>>>> GetQualifications(int userId)
        {
            var result = await _employeeDetailsService.GetQualificationsAsync(userId);
            return Ok(result);
        }
    }
}
