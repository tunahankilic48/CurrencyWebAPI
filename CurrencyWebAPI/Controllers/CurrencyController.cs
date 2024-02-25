using CurrencyWebAPI.Business.Models.DTOs.CurrencyDTOs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyVMs;
using CurrencyWebAPI.Service.Services.CurrencyService;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("GetAllCurrencies")]
        public async Task<List<CurrencyVM>> GetAllCurrencies()
        {
            return await _currencyService.GetAll();
        }

        [HttpGet("GetCurrencyById/{id}")]
        public async Task<CurrencyVM> GetCurrencyById(int id)
        {
            return await _currencyService.GetById(id);
        }

        [HttpPost("AddCurrency")]
        public async Task AddCurrency(CreateCurrencyDTO createCurrencyDTO)
        {
            await _currencyService.Create(createCurrencyDTO);
        }

        [HttpPut("UpdateCurrency")]
        public async Task UpdateCurrency(UpdateCurrencyDTO updateCurrencyDTO)
        {
            await _currencyService.Update(updateCurrencyDTO);
        }

        [HttpDelete("DeleteCurrency/{id}")]
        public async Task DeleteCurrency(int id)
        {
            await _currencyService.Delete(id);
        }
    }
}
