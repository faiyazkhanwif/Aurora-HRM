namespace AuroraHRMPWA.Server.Services.EmployeeDetailsService
{
    public class EmployeeDetailsService : IEmployeeDetailsService
    {
        private readonly DataContext _context;

        public EmployeeDetailsService(DataContext context)
        {
            _context = context;
        }
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
    }
}
