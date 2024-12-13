using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
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

        public async Task<AuthResponse> RegisterRequest(RegisterRequest request)
        {
            if (request is not null)
            {
                var res = await _apiService.WebApi.RegisterAsync(body: request);
                if (res is AuthResponse response)
                {
                    SetJWTAfterSuccessfulLogin(response.Token);
                    return response;
                }
            }
            return null;
        }

        public async Task<AuthResponse> LoginRequest(LoginRequest request)
        {
            if (request is not null)
            {
                var res = await _apiService.WebApi.LoginAsync(body: request);
                if (res is AuthResponse response)
                {
                    SetJWTAfterSuccessfulLogin(response.Token);
                    return response;
                }
            }
            return null;
        }

        public void SetJWTAfterSuccessfulLogin(string jwt)
        {
            Console.WriteLine("JWT token in header set");
            _apiService.SetJwtToken(jwt);
        }

        public void ClearJWT()
        {
            _apiService.SetJwtToken("");
        }
    }
}