using CurrencyWebAPI.Business.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace CurrencyWebAPI.Business.IoC
{
    public static class QuartzDependencyInjection
    {
        public static void AddQuartzDependency(this IServiceCollection services)
        {
            services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();
                var getCurrencyValueJobjobKey = JobKey.Create(nameof(GetCurrencyValueJob));
                options
                    .AddJob<GetCurrencyValueJob>(getCurrencyValueJobjobKey)
                    .AddTrigger(trigger => trigger
                                    .ForJob(getCurrencyValueJobjobKey)
                                    //.WithCronSchedule("0 0/1 * 1/1 * ? *"));
                                    .WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(5).RepeatForever()));

                var createCurrencyHourlyValuesJobjobKey = JobKey.Create(nameof(CreateCurrencyHourlyValuesJob));
                options
                    .AddJob<CreateCurrencyHourlyValuesJob>(createCurrencyHourlyValuesJobjobKey)
                    .AddTrigger(trigger => trigger
                                    .ForJob(createCurrencyHourlyValuesJobjobKey)
                                    .WithCronSchedule("0 0 0/1 1/1 * ? *"));
                                    //.WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(5).RepeatForever()));

                var createCurrencyDailyValuesjobKey = JobKey.Create(nameof(CreateCurrencyDailyValuesJob));
                options
                    .AddJob<CreateCurrencyDailyValuesJob>(createCurrencyDailyValuesjobKey)
                    .AddTrigger(trigger => trigger
                                    .ForJob(createCurrencyDailyValuesjobKey)
                                    .WithCronSchedule("0 0 12 1/1 * ? *"));
                                    //.WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(5).RepeatForever()));
            });

            services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });
        }
    }
}
