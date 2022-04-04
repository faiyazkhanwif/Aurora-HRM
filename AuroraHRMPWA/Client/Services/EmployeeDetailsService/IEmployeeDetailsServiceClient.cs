namespace AuroraHRMPWA.Client.Services.EmployeeDetailsService
{
    public interface IEmployeeDetailsServiceClient
    {
        Task<ServiceResponse<User>> GetUserDetail(int userId);
    }
}
