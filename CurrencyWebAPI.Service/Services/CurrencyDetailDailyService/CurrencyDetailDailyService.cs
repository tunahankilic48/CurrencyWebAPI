using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyVMs;
using CurrencyWebAPI.Business.Services.CurrencyDetailHourlyService;
using CurrencyWebAPI.Domain.Entities;
using CurrencyWebAPI.Domain.Repositories;
using CurrencyWebAPI.Service.Services.CurrencyDetailService;
using CurrencyWebAPI.Service.Services.CurrencyService;

namespace CurrencyWebAPI.Business.Services.CurrencyDetailDailyService
{
    internal class CurrencyDetailDailyService : ICurrencyDetailDailyService
    {
        private readonly ICurrencyDetailHourlyService _currencyDetailHourlyService;
        private readonly ICurrencyDetailDailyRepository _currencyDetailDailyRepository;
        private readonly ICurrencyService _currencyService;


        public CurrencyDetailDailyService(ICurrencyDetailHourlyService currencyDetailHourlyService, ICurrencyDetailDailyRepository currencyDetailDailyRepository, ICurrencyService currencyService)
        {
            _currencyDetailHourlyService = currencyDetailHourlyService;
            _currencyDetailDailyRepository = currencyDetailDailyRepository;
            _currencyService = currencyService;
        }

        public async Task CreateDailyValues()
        {
            List<CurrencyVM> currencies = await _currencyService.GetAll();
            int day = DateTime.Now.Day - 1;
            List<CurrencyDetailDaily> currencyDetailsDaily = new List<CurrencyDetailDaily>();

            foreach (CurrencyVM currency in currencies)
            {
                double total = 0;
                double maxValue = 0;
                double minValue = 0;
                List<CurrencyDetailHourly> currencyDetailsHourly = await _currencyDetailHourlyService.GetCurrencyDetailHourlyValues(currency.Id, day);
                foreach (var currencyDetailHourly in currencyDetailsHourly)
                {
                    double currencyAvarageValue = Double.Parse(currencyDetailHourly.AvarageValue);
                    double currencyMaxValue = Double.Parse(currencyDetailHourly.MaxValue);
                    double currencyMinValue = Double.Parse(currencyDetailHourly.MinValue);


                    maxValue = currencyMaxValue < maxValue ? maxValue : currencyMaxValue;
                    minValue = currencyMinValue > minValue ? minValue : currencyMinValue;
                    total += currencyAvarageValue;
                }
                double avarageValue = total / (double)currencyDetailsHourly.Count;

                CurrencyDetailDaily currencyDetailDaily = new CurrencyDetailDaily()
                {
                    CurrencyId = currency.Id,
                    Date = DateTime.Now,
                    AvarageValue = avarageValue.ToString(),
                    MaxValue = maxValue.ToString(),
                    MinValue = minValue.ToString()
                };
                currencyDetailsDaily.Add(currencyDetailDaily);
                await _currencyDetailDailyRepository.AddRange(currencyDetailsDaily);
            }
        }
    }
}
