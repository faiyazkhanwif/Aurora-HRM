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
        public Task<ServiceResponse<List<BankAccount>>> GetBankAccountsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<EmployeeExperience>>> GetEmployeeExperiencesAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<EmploymentDetail>>> GetEmploymentDetailsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FamilyMember>>> GetFamilyMembersAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Qualification>>> GetQualificationsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<User>> GetUserAsync(int userId)
        {
            //userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            //var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            //var userstr = state.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //int userId = int.Parse(userstr);
            var response = new ServiceResponse<User>();
            
            var user = await _context.Users.FindAsync(userId);
            if(user == null)
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
