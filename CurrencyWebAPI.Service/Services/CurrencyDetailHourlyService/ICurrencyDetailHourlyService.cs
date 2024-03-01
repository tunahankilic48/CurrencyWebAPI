using CurrencyWebAPI.Domain.Entities;

namespace CurrencyWebAPI.Business.Services.CurrencyDetailHourlyService
{
    public interface ICurrencyDetailHourlyService
    {
        Task CreateHourlyValues();
        Task<List<CurrencyDetailHourly>> GetCurrencyDetailHourlyValues(int currencyId, int day);
    }
}
