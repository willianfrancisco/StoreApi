using System.ComponentModel.DataAnnotations;

namespace Store.Application.DTOs
{
    public class PurchaseDTO
    {
        [Required(ErrorMessage = "{0} is required, can´t be null or empty")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "{0} is required, can´t be null or empty")]
        public string ClientName { get; set; }

        [Required(ErrorMessage = "{0} is required, can´t be null or empty")]
        public int TotalToPay { get; set; }

        public CreditCardDTO CreditCard { get; set; }
    }
}