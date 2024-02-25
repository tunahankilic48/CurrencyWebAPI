namespace CurrencyWebAPI.Business.Models.DTOs.CurrencyDetailDTOs
{
    public class CreateCurrencyDetailDTO
    {
        public int CurrencyId { get; set; }
        public DateTime Date { get; set; }
        public string? Value { get; set; }
    }
}
