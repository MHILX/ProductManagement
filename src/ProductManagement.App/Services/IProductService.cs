using ProductManagement.App.DTOs;

namespace ProductManagement.App.Services
{
    /// <summary>
    ///  The ProductService plays a crucial role in encapsulating business logic and 
    ///  ensuring that the application remains modular, maintainable, and testable.
    /// </summary>
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();
        ProductDto? GetProductById(int id);
        void AddProduct(ProductDto productDto);
        void UpdateProduct(ProductDto productDto);
        void DeleteProduct(int id);
    }
}

