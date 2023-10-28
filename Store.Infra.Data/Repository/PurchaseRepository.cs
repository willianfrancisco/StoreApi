using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Interfaces;
using Store.Infra.Data.Context;

namespace Store.Infra.Data.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly StoreContext _storeContext;

        public PurchaseRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<bool> Buy(Purchase purchase)
        {
            _storeContext.Purchases.Add(purchase);
            var result = await _storeContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchases()
        {
            var purchases = await _storeContext.Purchases.AsNoTracking()
                                    .Include(c => c.CreditCard).ToListAsync();
            return purchases;
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByClientId(string clientId)
        {
            var purchases = await _storeContext.Purchases.AsNoTracking()
                            .Include(c => c.CreditCard)
                            .Where(c => c.Id == Guid.Parse(clientId)).ToListAsync();
            return purchases;
        }
    }
}