namespace AuroraHRMPWA.Client.Services.EmployeeDetailsService
{
    public interface IEmployeeDetailsServiceClient
    {
        Task<ServiceResponse<User>> GetUserDetail(int userId);
        Task<ServiceResponse<EmploymentDetail>> GetEmploymentDetails(int userId);
        Task<ServiceResponse<List<BankAccount>>> GetBankAccounts(int userId);
        Task<ServiceResponse<List<EmployeeExperience>>> GetEmployeeExperiences(int userId);
        Task<ServiceResponse<List<Qualification>>> GetQualifications(int userId);
    }
}
