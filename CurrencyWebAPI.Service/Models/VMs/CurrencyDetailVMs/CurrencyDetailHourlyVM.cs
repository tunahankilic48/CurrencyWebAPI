namespace CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs
{
    public class CurrencyDetailHourlyVM
    {
        public int CurrencyId { get; set; }
        public DateTime Date { get; set; }
        public string? AvarageValue { get; set; }
        public string? MaxValue { get; set; }
        public string? MinValue { get; set; }
    }
}
