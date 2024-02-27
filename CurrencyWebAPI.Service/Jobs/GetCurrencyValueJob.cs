using CurrencyWebAPI.Service.Services.CurrencyDetailService;
using Quartz;

namespace CurrencyWebAPI.Business.Jobs
{
    public class GetCurrencyValueJob : IJob
    {
        private readonly ICurrencyDetailService _currencyDetailService;

        public GetCurrencyValueJob(ICurrencyDetailService currencyDetailService)
        {
            _currencyDetailService = currencyDetailService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _currencyDetailService.Create();
        }
    }
}
