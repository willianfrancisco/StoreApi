using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infra.Data.Context;

namespace Store.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<bool> AddProductToCart(Product product)
        {
            _storeContext.Products.Add(product);
            var result = await _storeContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _storeContext.Products.AsNoTracking().ToListAsync();
            return products;
        }
    }
}