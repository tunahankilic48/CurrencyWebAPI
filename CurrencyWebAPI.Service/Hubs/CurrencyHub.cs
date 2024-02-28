using CurrencyWebAPI.Service.Services.CurrencyDetailService;
using Microsoft.AspNetCore.SignalR;

namespace CurrencyWebAPI.Business.Hubs
{
    public class CurrencyHub : Hub
    {
        private readonly ICurrencyDetailService _currencyDetailService;

        public CurrencyHub(ICurrencyDetailService currencyDetailService)
        {
            _currencyDetailService = currencyDetailService;
        }


        public async Task SendCurrentCurrencyValue()
        {
            await Clients.All.SendAsync("CurrentCurrencyValue", await _currencyDetailService.GetLastValues());
        }
    }
}
