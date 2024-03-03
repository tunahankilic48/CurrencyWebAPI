using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebAPI.Service.Services.CurrencyDetailService;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyDetailController : ControllerBase
    {
        private readonly ICurrencyDetailService _currencyDetailService;

        public CurrencyDetailController(ICurrencyDetailService currencyDetailService)
        {
            _currencyDetailService = currencyDetailService;
        }

        [HttpGet("GetLastValueOfCurrencies")]
        public async Task<List<CurrencyDetailVM>> GetLastValueOfCurrencies()
        {
            return await _currencyDetailService.GetLastValues();
        }

    }
}
