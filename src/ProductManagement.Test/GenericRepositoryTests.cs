using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Entities;
using ProductManagement.Infra.Contexts;
using ProductManagement.Infra.Repositories;
using Xunit;

namespace ProductManagement.Test
{
    public class GenericRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        // private readonly ProductContext _context;
        // private readonly GenericRepository<Product, ProductContext> _repository;

        public GenericRepositoryTests(DatabaseFixture fixture)
        {
            // _context = fixture.Context;
            // _repository = new GenericRepository<Product, ProductContext>(_context);
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAllAsync_ReturnsAllEntitiesAsync()
        {
            // Arrange
            using var context = _fixture.CreateContext();
            using var repository = new GenericRepository<Product, ProductContext>(context);

            // Reset the database before the test
            await context.Database.EnsureDeletedAsync();

            var products = new List<Product>
            {
                new() { Id = 1, Name = "Product1", Price = 10 },
                new() { Id = 2, Name = "Product2", Price = 20 }
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsEntityAsync()
        {
            // Arrange
            using var context = _fixture.CreateContext();
            using var repository = new GenericRepository<Product, ProductContext>(context);

            // Reset the database before the test
            await context.Database.EnsureDeletedAsync();

            var product = new Product { Id = 1, Name = "Product1", Price = 10 };
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            // Act
            var result = await repository.GetByIdAsync<int>(1);

            // Assert
            Assert.Equal(product, result);
        }
    }

    public class DatabaseFixture : IDisposable
    {
        private readonly DbContextOptions<ProductContext> _options;

        public DatabaseFixture()
        {
            _options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            Context = new ProductContext(_options);
        }

        public ProductContext Context { get; private set; }

        /// <summary>
        /// This approach ensures that each test gets its own fresh ProductContext instance 
        /// while still connecting to the same in-memory database.
        /// </summary>
        /// <returns></returns>
        public ProductContext CreateContext()
        {
            return new ProductContext(_options);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
