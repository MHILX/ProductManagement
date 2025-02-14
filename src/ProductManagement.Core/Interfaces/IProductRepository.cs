using ProductManagement.Core.Entities;

namespace ProductManagement.Core.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // Additional methods specific to Product can be added here
    }
}
