using Store.Application.DTOs;

namespace Store.Application.Interfaces
{
    public interface IPurchaseService
    {
        Task<bool> Buy(PurchaseDTO purchase);
        Task<IEnumerable<HistorycDTO>> GetAllPurchases();
        Task<IEnumerable<HistorycDTO>> GetPurchasesByClientId(string clientId);
    }
}