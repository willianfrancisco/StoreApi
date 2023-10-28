using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> AddProductToCart(Product product);
        Task<IEnumerable<Product>> GetAllProducts();
    }
}