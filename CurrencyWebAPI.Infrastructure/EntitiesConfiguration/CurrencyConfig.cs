using CurrencyWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyWebAPI.Infrastructure.EntitiesConfiguration
{
    internal class CurrencyConfig : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnOrder(1);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR(20)")
                .HasColumnOrder(2);

            builder.Property(x => x.AttributeName)
                .IsRequired(true)
                .HasColumnType("VARCHAR(20)")
                .HasColumnOrder(3);
        }
    }
}
