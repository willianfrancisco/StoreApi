using System.ComponentModel.DataAnnotations;

namespace Store.Application.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "{0} is required, can´t be null or empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required, can´t be negative")]
        public int Price { get; set; }

        [Required(ErrorMessage = "{0} is required, can´t be null or empty")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "{0} is required, can´t be null or empty")]
        public string Seller { get; set; }

        [Required(ErrorMessage = "{0} is required, can´t be null or empty")]
        public string ThumbnailHd { get; set; }

        [Required(ErrorMessage = "{0} is required, can´t be null or empty")]
        public string Date { get; set; }
    }
}