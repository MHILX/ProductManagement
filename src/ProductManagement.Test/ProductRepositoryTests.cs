﻿using Microsoft.EntityFrameworkCore;
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
                 .UseInMemoryDatabase(databaseName: $"TestDatabase_{Guid.NewGuid}")
                 .Options;

            _context = new ProductContext(options);

            // Seed the in-memory database with test data
            SeedDatabase();

            _productRepository = new ProductRepository(_context);            
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
        public async Task GetProducts_ReturnsAllProductsAsync()
        {
            // Act
            var products = await _productRepository.GetAllAsync();

            // Assert
            Assert.NotNull(products);
            Assert.NotEmpty(products);
            Assert.IsAssignableFrom<IEnumerable<Product>>(products);
        }
    }
}
