using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;

namespace CurrencyWebAPI.Business.Services.CurrencyDetailDailyService
{
    public interface ICurrencyDetailDailyService
    {
        Task CreateDailyValues();
        Task<List<CurrencyDetailDailyVM>> GetCurrencyDetailDailylyValues(int year, int month, int day);
    }
}
