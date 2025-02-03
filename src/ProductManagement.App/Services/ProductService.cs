using ProductManagement.App.DTOs;
using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces;

namespace ProductManagement.App.Services
{
    public class ProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            IEnumerable<Product> products = _productRepo.GetAllProducts();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            });
        }

        public ProductDto? GetProductById(int id)
        {
            var product = _productRepo.GetAllProducts().FirstOrDefault(p => p.Id == id);
            
            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
        }
    }
}
