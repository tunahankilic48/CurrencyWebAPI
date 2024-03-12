using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyVMs;
using CurrencyWebAPI.Business.Services.CurrencyDetailHourlyService;
using CurrencyWebAPI.Domain.Entities;
using CurrencyWebAPI.Domain.Repositories;
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
            try
            {
                foreach (CurrencyVM currency in currencies)
                {
                    double total = 0;
                    double maxValue = int.MinValue;
                    double minValue = int.MaxValue;
                    List<CurrencyDetailHourly> currencyDetailsHourly = await _currencyDetailHourlyService.GetCurrencyDetailHourlyValues(currency.Id, day);
                    foreach (var currencyDetailHourly in currencyDetailsHourly)
                    {
                        double currencyAvarageValue = currency.Id == 5 ? Double.Parse(currencyDetailHourly.AvarageValue.Substring(1)) : Double.Parse(currencyDetailHourly.AvarageValue);
                        double currencyMaxValue = currency.Id == 5 ? Double.Parse(currencyDetailHourly.MaxValue.Substring(1)) : Double.Parse(currencyDetailHourly.MaxValue);
                        double currencyMinValue = currency.Id == 5 ? Double.Parse(currencyDetailHourly.MinValue.Substring(1)) : Double.Parse(currencyDetailHourly.MinValue);


                        maxValue = currencyMaxValue < maxValue ? maxValue : currencyMaxValue;
                        minValue = currencyMinValue > minValue ? minValue : currencyMinValue;
                        total += currencyAvarageValue;
                    }
                    double avarageValue = total / (double)currencyDetailsHourly.Count;

                    avarageValue = Math.Round(avarageValue, 3);
                    maxValue = Math.Round(maxValue, 3);
                    minValue = Math.Round(minValue, 3);

                    CurrencyDetailDaily currencyDetailDaily = new CurrencyDetailDaily()
                    {
                        CurrencyId = currency.Id,
                        Date = DateTime.Now,
                        AvarageValue = currency.Id == 5 ? avarageValue.ToString().Insert(0, "$") : avarageValue.ToString(),
                        MaxValue = currency.Id == 5 ? maxValue.ToString().Insert(0, "$") : maxValue.ToString(),
                        MinValue = currency.Id == 5 ? minValue.ToString().Insert(0, "$") : minValue.ToString()
                    };
                    currencyDetailsDaily.Add(currencyDetailDaily);
                }
                await _currencyDetailDailyRepository.AddRange(currencyDetailsDaily);
            }
            catch (Exception e)
            {
                var error = e.Message;
                throw;
            }
            
        }

        public async Task<List<CurrencyDetailDailyVM>> GetCurrencyDetailDailylyValues(int year, int month, int day)
        {
            List<CurrencyDetailDailyVM> currencyDetailsHourly = await _currencyDetailDailyRepository.GetFilteredList(
                select: x => new CurrencyDetailDailyVM()
                {
                    CurrencyId = x.CurrencyId,
                    Date = x.Date,
                    AvarageValue = x.AvarageValue,
                    MaxValue = x.MaxValue,
                    MinValue = x.MinValue
                },
                where: x => x.Date.Year == year && x.Date.Month == month && x.Date.Day == day,
                orderby: null,
                include: null
                );
            return currencyDetailsHourly;
        }
    }
}
