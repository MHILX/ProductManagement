using ProductManagement.Core.Entities;

namespace ProductManagement.Core.Interfaces
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();
    }
}
