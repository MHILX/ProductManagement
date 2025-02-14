using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces;
using ProductManagement.Infra.Contexts;

namespace ProductManagement.Infra.Repositories
{
    public class ProductRepository : 
        GenericRepository<Product, ProductContext>, 
        IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
    }
}
