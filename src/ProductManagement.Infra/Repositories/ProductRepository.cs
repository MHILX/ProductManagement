using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces;
using ProductManagement.Infra.Contexts;

namespace ProductManagement.Infra.Repositories
{

    /// <summary>
    /// The ProductRepository plays a specific role in the project by providing a 
    /// concrete implementation of the IProductRepository interface, which extends 
    /// the generic repository functionality for the Product entity. It serves as 
    /// a bridge between the data access layer and the business logic layer, 
    /// ensuring that data operations related to Product entities are handled 
    /// efficiently and consistently.
    /// </summary>
    public class ProductRepository : 
        GenericRepository<Product, ProductContext>, 
        IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
    }
}
