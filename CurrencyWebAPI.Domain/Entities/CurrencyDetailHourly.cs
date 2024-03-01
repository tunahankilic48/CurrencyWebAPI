namespace CurrencyWebAPI.Domain.Entities
{
    public class CurrencyDetailHourly
    {
        public int CurrencyId { get; set; }
        public DateTime Date { get; set; }
        public string? AvarageValue { get; set; }
        public string? MaxValue { get; set; }
        public string? MinValue { get; set; }

        public Currency? Currency { get; set; }
    }
}
