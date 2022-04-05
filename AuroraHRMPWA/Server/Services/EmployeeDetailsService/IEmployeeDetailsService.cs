namespace AuroraHRMPWA.Server.Services.EmployeeDetailsService
{
    public interface IEmployeeDetailsService
    {
        Task<ServiceResponse<User>> GetUserAsync(int userId);
        Task<ServiceResponse<List<FamilyMember>>> GetFamilyMembersAsync(int userId);
        Task<ServiceResponse<List<BankAccount>>> GetBankAccountsAsync(int userId);
        Task<ServiceResponse<List<EmployeeExperience>>> GetEmployeeExperiencesAsync(int userId);
        Task<ServiceResponse<EmploymentDetail>> GetEmploymentDetailsAsync(int userId);
        Task<ServiceResponse<List<Qualification>>> GetQualificationsAsync(int userId);
    }
}
