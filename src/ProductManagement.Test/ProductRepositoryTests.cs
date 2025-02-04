using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces;
using ProductManagement.Infra.Repositories;
using Xunit;

namespace ProductManagement.Test
{
    public class ProductRepositoryTests
    {
        private readonly IProductRepo _productRepository;

        public ProductRepositoryTests()
        {
            _productRepository = new ProductRepo();
        }

        [Fact]
        public void GetProducts_ReturnsAllProducts()
        {
            // Arrange
            
            // Act
            var products = _productRepository.GetAllProducts();

            // Assert
            Assert.NotNull(products);
            Assert.NotEmpty(products);
            Assert.IsAssignableFrom<IEnumerable<Product>>(products);
        }
    }
}
