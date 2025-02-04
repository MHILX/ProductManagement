using Microsoft.AspNetCore.Mvc;
using ProductManagement.App.Services;
using System.Diagnostics.CodeAnalysis;

namespace ProductManagement.API.Controllers
{
    /// <summary>
    /// Controller for managing products.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public sealed class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        /// <summary>
        /// Constructor for ProductsController.
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="logger"></param>
        public ProductsController(ProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
            _logger.LogInformation("Instantiated {ControllerName}", nameof(ProductsController));
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetProducts")]
        public IActionResult Get()
        {
            _logger.LogInformation("Invoked {MethodName}", nameof(Get));
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        /// <summary>
        /// Get product by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetProductById")]
        public IActionResult GetProductById(int id)
        {
            _logger.LogInformation("Invoked {MethodName} with ID: {Id}", nameof(GetProductById), id);
            var product = _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
