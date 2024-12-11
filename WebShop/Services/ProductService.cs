using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebShop.Services
{
    public class ProductService
    {
        private readonly ApiService _apiService;

        public ProductService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var res = await _apiService.WebApi.ProductsAllAsync();
            var casted = res as IEnumerable<Product>;
            return casted;
        }
    }
}