namespace WebShop.Services
{
    public class ApiService
    {
        private readonly WebApi _swaggerClient;
        private readonly HttpClient _httpClient;

        public ApiService(string apiBaseUrl)
        {
            _httpClient = new HttpClient();
            _swaggerClient = new WebApi(apiBaseUrl, _httpClient);
        }

        public WebApi WebApi { get { return _swaggerClient; } }
    }
}
