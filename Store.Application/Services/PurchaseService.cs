using AutoMapper;
using Store.Application.DTOs;
using Store.Application.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Interfaces;

namespace Store.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IMapper _mapper;
        private readonly IPurchaseRepository _purchaseRepository;

        public PurchaseService(IMapper mapper, IPurchaseRepository purchaseRepository)
        {
            _mapper = mapper;
            _purchaseRepository = purchaseRepository;
        }

        public async Task<bool> Buy(PurchaseDTO purchaseDTO)
        {
            var purchase = _mapper.Map<Purchase>(purchaseDTO);
            return await _purchaseRepository.Buy(purchase);
        }

        public async Task<IEnumerable<HistorycDTO>> GetAllPurchases()
        {
            var purchases = await _purchaseRepository.GetAllPurchases();
            return _mapper.Map<IEnumerable<HistorycDTO>>(purchases);
        }

        public async Task<IEnumerable<HistorycDTO>> GetPurchasesByClientId(string clientId)
        {
            var purchases = await _purchaseRepository.GetAllPurchases();
            return _mapper.Map<IEnumerable<HistorycDTO>>(purchases);
        }
    }
}