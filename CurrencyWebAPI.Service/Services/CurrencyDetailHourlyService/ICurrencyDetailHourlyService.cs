using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebAPI.Domain.Entities;

namespace CurrencyWebAPI.Business.Services.CurrencyDetailHourlyService
{
    public interface ICurrencyDetailHourlyService
    {
        Task CreateHourlyValues();
        Task<List<CurrencyDetailHourly>> GetCurrencyDetailHourlyValues(int currencyId, int day);
        Task<List<CurrencyDetailHourlyVM>> GetCurrencyDetailHourlyValuesInExactTime(int year, int month, int day, int hour);
    }
}
