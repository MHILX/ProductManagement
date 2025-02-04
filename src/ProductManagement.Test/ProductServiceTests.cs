using ProductManagement.App.DTOs;
using ProductManagement.App.Services;
using ProductManagement.Core.Interfaces;
using ProductManagement.Infra.Repositories;
using Xunit;

namespace ProductManagement.Test
{
    public class ProductServiceTests
    {
        private readonly IProductRepo _productRepo;

        public ProductServiceTests()
        {
            _productRepo = new ProductRepo();
        }

        [Fact]
        public void Test_GetAllProduct()
        {
            // Arrange
            var productService = new ProductService(_productRepo);

            // Act
            IEnumerable<ProductDto> products = productService.GetAllProducts();

            // Assert
            Assert.NotNull(products);
            Assert.NotEmpty(products);
            Assert.IsAssignableFrom<IEnumerable<ProductDto>>(products);        
        }

        [Fact]
        public void Test_GetProductById()
        {
            // Arrange
            var product = _productRepo.GetAllProducts().FirstOrDefault();
            var productService = new ProductService(_productRepo);

            // Act
            ProductDto? productDto = productService.GetProductById(1);

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
