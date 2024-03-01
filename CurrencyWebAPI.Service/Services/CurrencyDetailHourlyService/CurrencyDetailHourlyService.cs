using CurrencyWebAPI.Business.Models.VMs.CurrencyDetailVMs;
using CurrencyWebAPI.Business.Models.VMs.CurrencyVMs;
using CurrencyWebAPI.Domain.Entities;
using CurrencyWebAPI.Domain.Repositories;
using CurrencyWebAPI.Service.Services.CurrencyDetailService;
using CurrencyWebAPI.Service.Services.CurrencyService;

namespace CurrencyWebAPI.Business.Services.CurrencyDetailHourlyService
{
    internal class CurrencyDetailHourlyService : ICurrencyDetailHourlyService
    {
        private readonly ICurrencyDetailService _currencyDetailService;
        private readonly ICurrencyDetailHourlyRepository _currencyDetailHourlyRepository;
        private readonly ICurrencyService _currencyService;

        public CurrencyDetailHourlyService(ICurrencyDetailService currencyDetailService, ICurrencyService currencyService, ICurrencyDetailHourlyRepository currencyDetailHourlyRepository)
        {
            _currencyDetailService = currencyDetailService;
            _currencyService = currencyService;
            _currencyDetailHourlyRepository = currencyDetailHourlyRepository;
        }

        public async Task CreateHourlyValues()
        {
            List<CurrencyVM> currencies = await _currencyService.GetAll();
            int hour = DateTime.Now.Hour - 1;
            List<CurrencyDetailHourly> currencyDetailsHourly = new List<CurrencyDetailHourly>();

            foreach (CurrencyVM currency in currencies)
            {
                double total = 0;
                double maxValue = 0;
                double minValue = 0;
                List<CurrencyDetailVM> currencyDetails =  await _currencyDetailService.GetHourlyValues(currency.Id, hour);
                foreach (var currencyDetail in currencyDetails)
                {
                    double currencyValue = Double.Parse(currencyDetail.Value);
                    maxValue = currencyValue < maxValue ? maxValue : currencyValue;
                    minValue = currencyValue > minValue ? minValue : currencyValue;
                    total += currencyValue;
                }
                double avarageValue = total / (double)currencyDetails.Count;

                CurrencyDetailHourly currencyDetailHourly = new CurrencyDetailHourly()
                {
                    CurrencyId = currency.Id,
                    Date = DateTime.Now,
                    AvarageValue = avarageValue.ToString(),
                    MaxValue = maxValue.ToString(),
                    MinValue = minValue.ToString()
                };
                currencyDetailsHourly.Add(currencyDetailHourly);
            }

            await _currencyDetailHourlyRepository.AddRange(currencyDetailsHourly);
            await _currencyDetailService.DeleteCurrencyDetailInHour(hour);

        }

        public async Task<List<CurrencyDetailHourly>> GetCurrencyDetailHourlyValues(int currencyId, int day)
        {
            List<CurrencyDetailHourly> currencyDetailsHourly = await _currencyDetailHourlyRepository.GetFilteredList(
                select: x => new CurrencyDetailHourly()
                {
                    CurrencyId = x.CurrencyId,
                    Date = x.Date,
                    AvarageValue = x.AvarageValue,
                    MaxValue = x.MaxValue,
                    MinValue = x.MinValue
                },
                where: x => x.Date.Day == day && x.CurrencyId == currencyId,
                orderby: null,
                include: null
                );
            return currencyDetailsHourly;
        }
    }
}
