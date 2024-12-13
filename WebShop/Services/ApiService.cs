using System.Net.Http.Headers;

namespace WebShop.Services
{
    public class ApiService
    {
        private readonly WebApi _swaggerClient;
        private readonly HttpClient _httpClient;

        public ApiService(string apiBaseUrl, string jwtToken = null)
        {
            _httpClient = new HttpClient();
            _swaggerClient = new WebApi(apiBaseUrl, _httpClient);

            if (!string.IsNullOrEmpty(jwtToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }
        }

        public WebApi WebApi => _swaggerClient;

        public void SetJwtToken(string jwtToken)
        {
            if (!string.IsNullOrEmpty(jwtToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }
        }
    }
}