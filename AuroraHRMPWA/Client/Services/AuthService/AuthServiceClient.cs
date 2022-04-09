
namespace AuroraHRMPWA.Client.Services.AuthService
{
    public class AuthServiceClient : IAuthServiceClient
    {
        private readonly HttpClient _http;

        public AuthServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<string>> ForgotPassword(UserForgotPassword request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/forgotpassword", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<string>> Login(UserLogin request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();

        }

        public async Task<ServiceResponse<int>> Register(UserRegister request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<string>> ResetPassword(UserResetPassword request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/resetpassword", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<bool>> SendMail(ForgotPasswordSendMail request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/sendmail", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
    }
}
