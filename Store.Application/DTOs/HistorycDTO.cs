namespace Store.Application.DTOs
{
    public class HistorycDTO
    {
        public string ClientId { get; set; }
        public string PurchaseId { get; set; }
        public int Value { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public string CardNumber { get; set; }
    }
}