using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop.Models;
using WebClasses;
using WebShop.Services;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public HomeController(
            ILogger<HomeController> logger,
            ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await _productService.GetProductsAsync();

                foreach (var product in products)
                {
                    _logger.LogInformation(
                        "Product - ID: {ProductId}, Name: {ProductName}, Price: {ProductPrice}",
                        product.Product_ID,
                        product.Name,
                        product.Price
                    );
                }

                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving products");
                return View(Enumerable.Empty<WebClasses.Product>());
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}