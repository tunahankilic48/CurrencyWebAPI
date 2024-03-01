using CurrencyWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyWebAPI.Infrastructure.EntitiesConfiguration
{
    internal class CurrencyDetailHourlyConfig : IEntityTypeConfiguration<CurrencyDetailHourly>
    {
        public void Configure(EntityTypeBuilder<CurrencyDetailHourly> builder)
        {
            builder.HasKey(c => new { c.CurrencyId, c.Date });

            builder.Property(x => x.CurrencyId).HasColumnOrder(1);

            builder.Property(x => x.Date)
                .HasColumnType("DATETIME")
                .HasColumnOrder(2);

            builder.Property(x => x.AvarageValue)
                .IsRequired(true)
                .HasColumnType("VARCHAR(10)")
                .HasColumnOrder(3);

            builder.Property(x => x.MaxValue)
                .IsRequired(true)
                .HasColumnType("VARCHAR(10)")
                .HasColumnOrder(4);

            builder.Property(x => x.MinValue)
                .IsRequired(true)
                .HasColumnType("VARCHAR(10)")
                .HasColumnOrder(5);

            builder.HasOne(x => x.Currency)
                .WithMany(x => x.CurrencyDetialHourlys)
                .HasForeignKey(x => x.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
