using CurrencyWebAPI.Domain.Entities;
using CurrencyWebAPI.Infrastructure.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CurrencyWebAPI.Infrastructure.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyDetail> CurrencyDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyConfig())
                        .ApplyConfiguration(new CurrencyDetailConfig());

            base.OnModelCreating(modelBuilder);
        }

    }
}
