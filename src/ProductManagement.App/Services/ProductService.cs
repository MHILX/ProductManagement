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

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            IEnumerable<Product> products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync<int>(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task AddProductAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync<int>(id);
            if (product != null)
            {
                await _productRepository.DeleteAsync(product);
            }
        }
    }
}
