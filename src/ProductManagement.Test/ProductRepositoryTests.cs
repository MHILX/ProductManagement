using Microsoft.EntityFrameworkCore;
using Moq;
using ProductManagement.Core.Entities;
using ProductManagement.Infra.Contexts;
using ProductManagement.Infra.Repositories;
using Xunit;

namespace ProductManagement.Test
{
    public class ProductRepositoryTests
    {
        private readonly ProductContext _context;
        private readonly ProductRepository _productRepository;

        public ProductRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                 .UseInMemoryDatabase(databaseName: "TestDatabase")
                 .Options;

            _context = new ProductContext(options);
            _productRepository = new ProductRepository(_context);

            // Seed the in-memory database with test data
            SeedDatabase();
        }

        private void SeedDatabase()
        {
            var products = new List<Product>
            {
                new() { Id = 1, Name = "Product 1", Price = 10, Description = "Description 1" },
                new() { Id = 2, Name = "Product 2", Price = 20, Description = "Description 2" }
            };

            _context.Products.AddRange(products);
            _context.SaveChanges();
        }

        [Fact]
        public void GetProducts_ReturnsAllProducts()
        {
            // Act
            var products = _productRepository.GetAll();

            // Assert
            Assert.NotNull(products);
            Assert.NotEmpty(products);
            Assert.IsAssignableFrom<IEnumerable<Product>>(products);
        }
    }
}
