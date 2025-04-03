using Microsoft.EntityFrameworkCore;
using Moq;
using ProductManagement.Core.Entities;
using ProductManagement.Infra.Contexts;
using ProductManagement.Infra.Repositories;
using Xunit;

namespace ProductManagement.Test
{
    public class GenericRepositoryTests
    {
        private readonly ProductContext _context;
        private readonly GenericRepository<Product, ProductContext> _repository;

        public GenericRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ProductContext(options);
            _repository = new GenericRepository<Product, ProductContext>(_context);
        }

        [Fact]
        public void GetAllAsync_ReturnsAllEntities()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product1", Price = 10 },
                new Product { Id = 2, Name = "Product2", Price = 20 }
            };

            _context.Products.AddRange(products);
            _context.SaveChanges();

            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetByIdAsync_ReturnsEntity()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product1", Price = 10 };
            _context.Products.Add(product);
            _context.SaveChangesAsync();

            // Act
            var result = _repository.GetById<int>(1);

            // Assert
            Assert.Equal(product, result);
        }
    }
}
