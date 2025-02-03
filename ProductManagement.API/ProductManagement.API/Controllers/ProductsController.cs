using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] Fruits = new[]
        {
            "Apple", "Banana", "Cherry", "Date", "Elderberry", "Fig", "Grape", "Honeydew", "Kiwi", "Lemon"
        };

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
            _logger.LogInformation("something");
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<DTOs.Product> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new DTOs.Product
            {
                Id = index,
                Name = $"Product {index}",
                Price = Random.Shared.Next(1, 1000),
                Description = Fruits[Random.Shared.Next(Fruits.Length)]
            })
            .ToArray();
        }
    }
}
