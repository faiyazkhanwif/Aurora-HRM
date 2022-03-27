
namespace AuroraHRMPWA.Client.Services.AuthService
{
    public interface IAuthServiceClient
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
    }
}
