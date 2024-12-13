using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<RegisterResponse> RegisterRequest(RegisterRequest request)
        {
            if (request is not null)
            {
                var res = await _apiService.WebApi.RegisterAsync(body: request);
                if (res is RegisterResponse response)
                {
                    return response;
                }
            }
            return null;
        }

        public async Task<LoginResponse> LoginRequest(LoginRequest request)
        {
            if (request is not null)
            {
                var res = await _apiService.WebApi.LoginAsync(body: request);
                if (res is LoginResponse response)
                {
                    return response;
                }
            }
            return null;
        }
    }
}