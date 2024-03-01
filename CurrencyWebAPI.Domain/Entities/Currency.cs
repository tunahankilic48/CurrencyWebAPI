namespace CurrencyWebAPI.Domain.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? AttributeName { get; set; }

        public List<CurrencyDetail>? CurrencyDetials { get; set; }
        public List<CurrencyDetailHourly>? CurrencyDetialHourlys { get; set; }
        public List<CurrencyDetailDaily>? CurrencyDetialDailys { get; set; }


    }
}
