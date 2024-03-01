using CurrencyWebAPI.Business.Services.CurrencyDetailHourlyService;
using Quartz;

namespace CurrencyWebAPI.Business.Jobs
{
    internal class CreateCurrencyHourlyValuesJob : IJob
    {
        private readonly ICurrencyDetailHourlyService _currencyDetailHourlyService;

        public CreateCurrencyHourlyValuesJob(ICurrencyDetailHourlyService currencyDetailHourlyService)
        {
            _currencyDetailHourlyService = currencyDetailHourlyService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _currencyDetailHourlyService.CreateHourlyValues();
        }
    }
}
