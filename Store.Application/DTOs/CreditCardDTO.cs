using System.ComponentModel.DataAnnotations;

namespace Store.Application.DTOs
{
    public class CreditCardDTO
    {
        [Required(ErrorMessage = "{0} is required, can´t be null or empty")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "{0} is required, can´t be negative")]
        public int Value { get; set; }

        [Required(ErrorMessage = "{0} is required, can´t be negative")]
        public int Cvv { get; set; }

        [Required(ErrorMessage = "{0} is required, can´t be null or empty")]
        public string CardHolderName { get; set; }

        [Required(ErrorMessage = "{0} is required, can´t be null or empty")]
        public string ExpDate { get; set; }
    }
}