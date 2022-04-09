
namespace AuroraHRMPWA.Client.Services.AuthService
{
    public interface IAuthServiceClient
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin request);
        Task<ServiceResponse<string>> ForgotPassword(UserForgotPassword request);
        Task<ServiceResponse<bool>> SendMail(ForgotPasswordSendMail request);
        Task<ServiceResponse<string>> ResetPassword(UserResetPassword request);
    }
}
