using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.App.Services;

namespace ProductManagement.API.Controllers
{
    /// <summary>
    /// Controller for managing products.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public sealed class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductsController> _logger;

        /// <summary>
        /// Constructor for ProductsController.
        /// </summary>
        /// <param name="productService"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public ProductsController(IProductService productService, IMapper mapper, ILogger<ProductsController> logger)
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
        public async Task<IActionResult> GetAsync()
        {
            _logger.LogInformation("Invoked {MethodName}", nameof(GetAsync));
            var products = await _productService.GetAllProductsAsync().ConfigureAwait(false);
            return Ok(products);
        }

        /// <summary>
        /// Get product by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            _logger.LogInformation("Invoked {MethodName} with ID: {Id}", nameof(GetProductByIdAsync), id);
            var product = await _productService.GetProductByIdAsync(id).ConfigureAwait(false);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
