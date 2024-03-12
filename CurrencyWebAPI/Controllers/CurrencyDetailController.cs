using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebAPI.Business.Services.CurrencyDetailDailyService;
using CurrencyWebAPI.Business.Services.CurrencyDetailHourlyService;
using CurrencyWebAPI.Service.Services.CurrencyDetailService;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyDetailController : ControllerBase
    {
        private readonly ICurrencyDetailService _currencyDetailService;
        private readonly ICurrencyDetailHourlyService _currencyDetailHourlyService;
        private readonly ICurrencyDetailDailyService _currencyDetailDailyService;

        public CurrencyDetailController(ICurrencyDetailService currencyDetailService, ICurrencyDetailHourlyService currencyDetailHourlyService, ICurrencyDetailDailyService currencyDetailDailyService)
        {
            _currencyDetailService = currencyDetailService;
            _currencyDetailHourlyService = currencyDetailHourlyService;
            _currencyDetailDailyService = currencyDetailDailyService;
        }

        [HttpGet("GetLastValueOfCurrencies")]
        public async Task<List<CurrencyDetailVM>> GetLastValueOfCurrencies()
        {
            return await _currencyDetailService.GetLastValues();
        }

        [HttpGet("GetHourlyValue")]
        public async Task<List<CurrencyDetailHourlyVM>> GetHourlyValue(int year, int month, int day, int hour)
        {
            return await _currencyDetailHourlyService.GetCurrencyDetailHourlyValuesInExactTime(year, month, day, hour);
        }

        [HttpGet("GetDailyValue")]
        public async Task<List<CurrencyDetailDailyVM>> GetDailyValue(int year, int month, int day)
        {
            return await _currencyDetailDailyService.GetCurrencyDetailDailylyValues(year, month, day);
        }

    }
}
