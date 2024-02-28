using Autofac.Extensions.DependencyInjection;
using Autofac;
using CurrencyWebAPI.Business.IoC;
using CurrencyWebAPI.Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Quartz;
using CurrencyWebAPI.Business.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Connection string will be taken from appsettings.json file

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddQuartzDependency();
builder.Services.AddSignalR();

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DependencyResolver());
}); // Dependency injection için kullanýlan container burada implimente edildi.

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");
app.MapHub<CurrencyHub>("/currencyHub");

app.MapControllers();

app.Run();
