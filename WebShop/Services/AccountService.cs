using Microsoft.AspNetCore.Identity.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebShop.Services
{
    public class AccountService
    {
        private readonly ApiService _apiService;

        public AccountService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task RegisterRequest(RegisterRequest request)
        {
            if (request == null)
            {
                return;
            }

            var res = _apiService.WebApi.RegisterAsync(body: request);
            if(res is not null)
            {

            }
        }

        public async Task LoginRequest(LoginRequest request)
        {
            if (request == null)
            {
                return;
            }

            var res = _apiService.WebApi.LoginAsync(body: request);
            if (res is not null)
            {

            }
        }

        public async Task GoogleAuth()
        {
            var res = _apiService.WebApi.LoginGoogleAsync();
            if (res is not null)
            {

            }
        }
    }
}