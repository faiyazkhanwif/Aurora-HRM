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

        public async Task<ServiceResponse<EmploymentDetail>> GetEmploymentDetails(int userId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<EmploymentDetail>>($"api/employeedetails/getemploymentdetails/{userId}");
            return result;
        }

        public async Task<ServiceResponse<List<BankAccount>>> GetBankAccounts(int userId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<BankAccount>>>($"api/employeedetails/getbankaccounts/{userId}");
            return result;
        }

        public async Task<ServiceResponse<List<EmployeeExperience>>> GetEmployeeExperiences(int userId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<EmployeeExperience>>>($"api/employeedetails/getemployeeexperiences/{userId}");
            return result;
        }

        public async Task<ServiceResponse<List<Qualification>>> GetQualifications(int userId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Qualification>>>($"api/employeedetails/getqualifications/{userId}");
            return result;
        }
    }
}
