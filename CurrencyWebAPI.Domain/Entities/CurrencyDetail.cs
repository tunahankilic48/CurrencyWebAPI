namespace CurrencyWebAPI.Domain.Entities
{
    public class CurrencyDetail
    {
        public int CurrencyId { get; set; }
        public DateTime Date { get; set; }
        public string? Value { get; set; }

        public Currency? Currency { get; set;}
    }
}
