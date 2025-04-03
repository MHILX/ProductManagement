using AutoMapper;
using Moq;
using ProductManagement.App.DTOs;
using ProductManagement.App.Profiles;
using ProductManagement.App.Services;
using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces;
using Xunit;

namespace ProductManagement.Test
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductServiceTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductMappingProfile>();
            });

            _mapper = config.CreateMapper();

            _productService = new ProductService(_mockProductRepository.Object, _mapper);

            // Set up mock data
            var products = new List<Product>
            {
                new() { Id = 1, Name = "Product 1", Price = 10, Description = "Description 1" },
                new() { Id = 2, Name = "Product 2", Price = 20, Description = "Description 2" }
            };

            _mockProductRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);
            _mockProductRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int id) => products.FirstOrDefault(p => p.Id == id));
        }

        [Fact]
        public async Task Test_GetAllProduct()
        {
            // Act
            IEnumerable<ProductDto> products = await _productService.GetAllProductsAsync();

            // Assert
            Assert.NotNull(products);
            Assert.NotEmpty(products);
            Assert.IsAssignableFrom<IEnumerable<ProductDto>>(products);
        }

        [Fact]
        public async Task Test_GetProductById()
        {
            // Arrange
            var product = (await _productService.GetAllProductsAsync()).FirstOrDefault();

            // Act
            ProductDto? productDto = await _productService.GetProductByIdAsync(product?.Id ?? 0);

            // Assert
            Assert.NotNull(productDto);
            Assert.IsType<ProductDto>(productDto);
            Assert.Equal(product?.Id, productDto.Id);
            Assert.Equal(product?.Name, productDto.Name);
            Assert.Equal(product?.Price, productDto.Price);
            Assert.Equal(product?.Description, productDto.Description);
        }
    }
}



