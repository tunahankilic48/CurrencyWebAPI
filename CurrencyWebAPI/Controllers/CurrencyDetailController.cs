using CurrencyWebAPI.Business.Models.DTOs.CurrencyDetailDTOs;
using CurrencyWebAPI.Business.Models.DTOs.CurrencyDTOs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebAPI.Service.Services.CurrencyDetailService;
using CurrencyWebAPI.Service.Services.CurrencyService;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("AddCurrencyDetail")]
        public async Task AddCurrencyDetail()
        {
            await _currencyDetailService.Create();
        }
    }
}
