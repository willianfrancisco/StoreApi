using Store.Application.DTOs;

namespace Store.Application.Interfaces
{
    public interface IProductService
    {
        Task<bool> AddProductToCart(ProductDTO productDTO);
        Task<IEnumerable<ProductDTO>> GetAllProducts();
    }
}