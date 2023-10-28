using Store.Domain.Validations;

namespace Store.Domain.Entities
{
    public sealed class CreditCard
    {
        public CreditCard(Guid id, string cardNumber, int value, int cvv, string cardHolderName, string expDate)
        {
            ValidateId(id);
            ValidateCardNumber(cardNumber);
            ValidateValue(value);
            ValidateCvv(cvv);
            ValidateCardHolderName(cardHolderName);
            ValidateExpDate(expDate);
        }

        public CreditCard(string cardNumber, int value, int cvv, string cardHolderName, string expDate)
        {
            ValidateCardNumber(cardNumber);
            ValidateValue(value);
            ValidateCvv(cvv);
            ValidateCardHolderName(cardHolderName);
            ValidateExpDate(expDate);
        }

        public CreditCard(Guid id,string cardNumber, int value, int cvv, string cardHolderName, string expDate, Guid purchaseId)
        {
            ValidateId(id);
            ValidateCardNumber(cardNumber);
            ValidateValue(value);
            ValidateCvv(cvv);
            ValidateCardHolderName(cardHolderName);
            ValidateExpDate(expDate);
            PurchaseId = purchaseId;
        }

        public Guid Id { get; private set; }
        public string CardNumber { get; private set; }
        public int Value { get; private set; }
        public int Cvv { get; private set; }
        public string CardHolderName { get; private set; }
        public string ExpDate { get; private set; }
        public Purchase Purchase { get; set; }
        public Guid PurchaseId { get; set; }

        private void ValidateId(Guid id)
        {
            DomainEntitiesValidation.When(id == Guid.Empty, "Id can´t be null or empty.");
            Id = id;
        }
        private void ValidateCardNumber(string cardNumber)
        {
            DomainEntitiesValidation.When(string.IsNullOrEmpty(cardNumber), "Card number can´t be null or empty.");
            CardNumber = cardNumber;
        }
        private void ValidateValue(int value)
        {
            DomainEntitiesValidation.When(value < 0, "Value can´t be negative.");
            Value = value;
        }
        private void ValidateCvv(int cvv)
        {
            DomainEntitiesValidation.When(cvv < 0, "Value can´t be negative.");
            Cvv = cvv;
        }
        private void ValidateCardHolderName(string holderName)
        {
            DomainEntitiesValidation.When(string.IsNullOrEmpty(holderName), "Card holder name can´t be null or empty.");
            CardHolderName = holderName;
        }

        private void ValidateExpDate(string expDate)
        {
            DomainEntitiesValidation.When(string.IsNullOrEmpty(expDate), "Card expirate date can´t be null or empty.");
            ExpDate = expDate;
        }
    }
}