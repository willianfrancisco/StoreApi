using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Entities;

namespace Store.Domain.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<bool> Buy(Purchase purchase);
        Task<IEnumerable<Purchase>> GetAllPurchases();
        Task<IEnumerable<Purchase>> GetPurchasesByClientId(string clientId);
    }
}