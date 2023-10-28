using AutoMapper;
using Store.Application.DTOs;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Interfaces;

namespace Store.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddProductToCart(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            return await _productRepository.AddProductToCart(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}