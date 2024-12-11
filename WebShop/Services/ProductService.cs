using System.Collections.Generic;
using System.Threading.Tasks;
using WebClasses;

namespace WebShop.Services
{
    public class ProductService
    {
        private readonly ApiService _apiService;
        private const string ProductEndpoint = "products/";

        public ProductService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<WebClasses.Product>> GetProductsAsync()
        {
            return await _apiService.GetListAsync<WebClasses.Product>(ProductEndpoint);
        }
    }
}