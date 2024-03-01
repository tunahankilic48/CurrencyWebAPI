using CurrencyWebAPI.Business.Services.CurrencyDetailDailyService;
using Quartz;

namespace CurrencyWebAPI.Business.Jobs
{
    internal class CreateCurrencyDailyValuesJob : IJob
    {
        private readonly ICurrencyDetailDailyService _currencyDetailDailyService;

        public CreateCurrencyDailyValuesJob(ICurrencyDetailDailyService currencyDetailDailyService)
        {
            _currencyDetailDailyService = currencyDetailDailyService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _currencyDetailDailyService.CreateDailyValues();
        }
    }
}
