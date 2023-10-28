using Store.Domain.Validations;

namespace Store.Domain.Entities
{
    public sealed class Product
    {
        public Product(Guid id, string title, int price, string zipCode, string seller, string thumbnailHd, string date)
        {
            ValidateId(id);
            ValidateTitle(title);
            ValidatePrice(price);
            ValidateZipCode(zipCode);
            ValidateSeller(seller);
            ValidateThumbnail(thumbnailHd);
            ValidateDate(date);
        }

        public Product(string title, int price, string zipCode, string seller, string thumbnailHd, string date)
        {
            ValidateTitle(title);
            ValidatePrice(price);
            ValidateZipCode(zipCode);
            ValidateSeller(seller);
            ValidateThumbnail(thumbnailHd);
            ValidateDate(date);
        }

        public Guid Id { get; set; }
        public string Title { get; private set; }
        public int Price { get; private set; }
        public string ZipCode { get; private set; }
        public string Seller { get; private set; }
        public string ThumbnailHd { get; private set; }
        public string Date { get; private set; }

        private void ValidateId(Guid id)
        {
            DomainEntitiesValidation.When(id == Guid.Empty, "Id can´t be null or empty.");
            Id = id;
        }

        private void ValidateTitle(string title)
        {
            DomainEntitiesValidation.When(string.IsNullOrEmpty(title), "Title can´t be null or empty.");
            Title = title;
        }

        private void ValidatePrice(int price)
        {
            DomainEntitiesValidation.When(price < 0, "Price can´t be negative.");
            Price = price;
        }

        private void ValidateZipCode(string zipCode)
        {
            DomainEntitiesValidation.When(string.IsNullOrEmpty(zipCode), "ZipCode can´t be null or empty.");
            ZipCode = zipCode;
        }

        private void ValidateSeller(string seller)
        {
            DomainEntitiesValidation.When(string.IsNullOrEmpty(seller), "Seller can´t be null or empty.");
            Seller = seller;
        }

        private void ValidateThumbnail(string thumbnail)
        {
            DomainEntitiesValidation.When(string.IsNullOrEmpty(thumbnail), "ThumbnailHd can´t be null or empty.");
            ThumbnailHd = thumbnail;
        }

        private void ValidateDate(string date)
        {
            DomainEntitiesValidation.When(string.IsNullOrEmpty(date), "Date can´t be null or empty.");
            Date = date;
        }
    }
}