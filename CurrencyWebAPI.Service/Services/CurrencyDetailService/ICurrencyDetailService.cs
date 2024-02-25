using CurrencyWebAPI.Business.Models.DTOs.CurrencyDetailDTOs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;

namespace CurrencyWebAPI.Service.Services.CurrencyDetailService
{
    public interface ICurrencyDetailService
    {
        Task Create(CreateCurrencyDetailDTO createCurrencyDetailDTO);
        Task<CurrencyDetailVM> GetLastValue(int currencyId);
    }
}
