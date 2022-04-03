namespace AuroraHRMPWA.Server.Services.EmployeeDetailsService
{
    public interface IEmployeeDetailsService
    {
        Task<ServiceResponse<User>> GetUserAsync(string userId);
        Task<ServiceResponse<List<FamilyMember>>> GetFamilyMembersAsync(string userId);
        Task<ServiceResponse<List<BankAccount>>> GetBankAccountsAsync(string userId);
        Task<ServiceResponse<List<EmployeeExperience>>> GetEmployeeExperiencesAsync(string userId);
        Task<ServiceResponse<List<EmploymentDetail>>> GetEmploymentDetailsAsync(string userId);
        Task<ServiceResponse<List<Qualification>>> GetQualificationsAsync(string userId);
    }
}
