using AutoMapper;
using ProductManagement.App.DTOs;
using ProductManagement.Core.Entities;
using ProductManagement.Core.Interfaces;

namespace ProductManagement.App.Services
{
    /// <summary>
    ///  The ProductService plays a crucial role in encapsulating business logic and 
    ///  ensuring that the application remains modular, maintainable, and testable.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _productRepository = productRepo;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            IEnumerable<Product> products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto? GetProductById(int id)
        {
            var product = _productRepository.GetById<int>(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public void AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Add(product);
        }

        public void UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById<int>(id);
            if (product != null)
            {
                _productRepository.Delete(product);
            }
        }
    }
}
