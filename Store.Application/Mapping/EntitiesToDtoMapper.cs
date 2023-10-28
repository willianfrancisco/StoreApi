using AutoMapper;
using Store.Application.DTOs;
using Store.Domain.Entities;

namespace Store.Application.Mapping
{
    public class EntitiesToDtoMapper : Profile
    {
        public EntitiesToDtoMapper()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Purchase, PurchaseDTO>().ReverseMap();

            CreateMap<CreditCard, CreditCardDTO>().ReverseMap();

            CreateMap<Purchase, HistorycDTO>()
                     .ForMember(dst => dst.ClientId, s => s.MapFrom(src => src.ClientId))
                     .ForMember(dst => dst.PurchaseId, s => s.MapFrom(src => src.Id))
                     .ForMember(dst => dst.Value, s => s.MapFrom(src => src.TotalToPay))
                     .ForMember(dst => dst.CardNumber, s => s.MapFrom(src => FormatCardNumber(src.CreditCard.CardNumber)));
        }

        private string FormatCardNumber(string cardNumber)
        {
            var newCardNumber = cardNumber.Substring(cardNumber.Length -4, 4);
            return $"**** **** **** {newCardNumber}";
        }
    }
}