using Autofac;
using AutoMapper;
using CurrencyWebAPI.Domain.Repositories;
using CurrencyWebAPI.Infrastructure.Repositories;
using CurrencyWebAPI.Service.Services.CurrencyDetailService;
using CurrencyWebAPI.Service.Services.CurrencyService;


namespace CurrencyWebAPI.Business.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();
            builder.RegisterType<CurrencyRepository>().As<ICurrencyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CurrencyDetailRepository>().As<ICurrencyDetailRepository>().InstancePerLifetimeScope();

            builder.RegisterType<CurrencyService>().As<ICurrencyService>().InstancePerLifetimeScope();
            builder.RegisterType<CurrencyDetailService>().As<ICurrencyDetailService>().InstancePerLifetimeScope();


            #region AutoMapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                //Register Mapper Profile
                cfg.AddProfile<CurrencyWebAPI.Business.Mapping.Mapping > (); /// AutoMapper klasörünün altına eklediğimiz Mapping classını bağlıyoruz.
            }
            )).AsSelf().SingleInstance();



            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
            #endregion

            base.Load(builder);
        }
    }
}
