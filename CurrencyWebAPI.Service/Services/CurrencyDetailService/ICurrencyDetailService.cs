using CurrencyWebAPI.Business.Models.DTOs.CurrencyDetailDTOs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;

namespace CurrencyWebAPI.Service.Services.CurrencyDetailService
{
    public interface ICurrencyDetailService
    {
        Task Create();
        Task<CurrencyDetailVM> GetLastValue(int currencyId);
        Task<List<CurrencyDetailVM>> GetLastValues();

    }
}
