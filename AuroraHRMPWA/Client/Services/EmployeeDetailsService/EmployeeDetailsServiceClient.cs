namespace AuroraHRMPWA.Client.Services.EmployeeDetailsService
{
    public class EmployeeDetailsServiceClient : IEmployeeDetailsServiceClient
    {
        private readonly HttpClient _http;

        public EmployeeDetailsServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<ServiceResponse<User>> GetUserDetail(int userId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<User>>($"api/employeedetails/getuser/{userId}");
            return result;
        }
    }
}
