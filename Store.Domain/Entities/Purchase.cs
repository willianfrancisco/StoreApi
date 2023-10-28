using Store.Domain.Validations;

namespace Store.Domain.Entities
{
    public sealed class Purchase
    {
        public Purchase(Guid id, string clientId, string clientName, int totalToPay)
        {
            ValidateId(id);
            ValidateClientId(clientId);
            ValidateClientName(clientName);
            ValidateTotalToPay(totalToPay);
        }

        public Purchase(string clientId, string clientName, int totalToPay)
        {
            ValidateClientId(clientId);
            ValidateClientName(clientName);
            ValidateTotalToPay(totalToPay);
        }

        public Guid Id { get; private set; }
        public string ClientId { get; private set; }
        public string ClientName { get; private set; }
        public int TotalToPay { get; private set; }
        public CreditCard CreditCard { get; set; }

        private void ValidateId(Guid id)
        {
            DomainEntitiesValidation.When(id == Guid.Empty, "Id can´t be null or empty;");
            Id = id;
        }
        private void ValidateClientId(string id)
        {
            DomainEntitiesValidation.When(string.IsNullOrEmpty(id), "Client id can´t be null or empty;");
            ClientId = id;
        }
        private void ValidateClientName(string name)
        {
            DomainEntitiesValidation.When(string.IsNullOrEmpty(name), "Client name can´t be null or empty;");
            ClientName = name;
        }
        private void ValidateTotalToPay(int total)
        {
            DomainEntitiesValidation.When(total < 0, "Total can´t be negative;");
            TotalToPay = total;
        }
    }
}