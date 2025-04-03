using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductManagement.API.Controllers;
using ProductManagement.App.DTOs;
using Xunit;
using ProductManagement.App.Services;
using AutoMapper;

namespace ProductManagement.Test
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<ILogger<ProductsController>> _mockLogger;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _mockProductService = new Mock<IProductService>();
            _mockLogger = new Mock<ILogger<ProductsController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new ProductsController(_mockProductService.Object, _mockMapper.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult_WithListOfProductsAsync()
        {
            // Arrange
            var products = new List<ProductDto>
            {
                new() { Id = 1, Name = "Product1", Price = 10 },
                new() { Id = 2, Name = "Product2", Price = 20 }
            };

            _mockProductService.Setup(service => service.GetAllProductsAsync()).ReturnsAsync(products);

            // Act
            var result = await _controller.GetAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnProducts = Assert.IsType<List<ProductDto>>(okResult.Value);
            Assert.Equal(2, returnProducts.Count);
        }

        [Fact]
        public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExistAsync()
        {
            // Arrange
            _mockProductService.Setup(service => service.GetProductByIdAsync(1)).ReturnsAsync(null as ProductDto);

            // Act
            var result = await _controller.GetProductByIdAsync(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }
    }
}
