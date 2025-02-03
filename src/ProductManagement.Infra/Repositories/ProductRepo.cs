using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces;

namespace ProductManagement.Infra.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private static readonly List<Product> Fruits = new()
        {
            new Product { Id = 1, Name = "Apple", Price = 1.99m, Description = "An apple a day keeps the doctor away" },
            new Product { Id = 2, Name = "Banana", Price = 0.99m, Description = "A banana a day keeps the doctor away" },
            new Product { Id = 3, Name = "Orange", Price = 2.99m, Description = "An orange a day keeps the doctor away" }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return Fruits;
        }
    }
}
