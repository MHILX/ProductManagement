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

            _mockProductRepository.Setup(repo => repo.GetAll()).Returns(products);
            _mockProductRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((int id) => products.FirstOrDefault(p => p.Id == id));
        }

        [Fact]
        public void Test_GetAllProduct()
        {
            // Act
            IEnumerable<ProductDto> products = _productService.GetAllProducts();

            // Assert
            Assert.NotNull(products);
            Assert.NotEmpty(products);
            Assert.IsAssignableFrom<IEnumerable<ProductDto>>(products);
        }

        [Fact]
        public void Test_GetProductById()
        {
            // Arrange
            var product = _productService.GetAllProducts().FirstOrDefault();

            // Act
            ProductDto? productDto = _productService.GetProductById(product?.Id ?? 0);

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



