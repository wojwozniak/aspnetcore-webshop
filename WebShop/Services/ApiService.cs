using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebShop.Services
{
    public class ApiService
    {
        protected readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public virtual async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<T>("api/" + endpoint);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching {typeof(T).Name}: {ex.Message}");
                return default;
            }
        }

        public virtual async Task<IEnumerable<T>> GetListAsync<T>(string endpoint)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<T>>("api/" + endpoint);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching list of {typeof(T).Name}: {ex.Message}");
                return new List<T>();
            }
        }

        public virtual async Task<T> CreateAsync<T>(string endpoint, T item)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/" + endpoint, item);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error creating {typeof(T).Name}: {ex.Message}");
                return default;
            }
        }

        public virtual async Task<T> UpdateAsync<T>(string endpoint, T item)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/" + endpoint, item);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<T>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error updating {typeof(T).Name}: {ex.Message}");
                return default;
            }
        }

        public virtual async Task DeleteAsync(string endpoint)
        {
            try
            {
                var response = await _httpClient.DeleteAsync("api/" + endpoint);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error deleting item: {ex.Message}");
            }
        }
    }
}