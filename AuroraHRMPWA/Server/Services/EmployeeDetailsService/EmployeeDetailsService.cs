namespace AuroraHRMPWA.Server.Services.EmployeeDetailsService
{
    public class EmployeeDetailsService : IEmployeeDetailsService
    {
        public Task<ServiceResponse<List<BankAccount>>> GetBankAccountsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<EmployeeExperience>>> GetEmployeeExperiencesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<EmploymentDetail>>> GetEmploymentDetailsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<FamilyMember>>> GetFamilyMembersAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<Qualification>>> GetQualificationsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<User>> GetUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
