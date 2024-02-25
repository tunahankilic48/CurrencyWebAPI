using CurrencyWebAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurrencyWebAPI.Infrastructure.EntitiesConfiguration
{
    internal class CurrencyDetailConfig : IEntityTypeConfiguration<CurrencyDetail>
    {
        public void Configure(EntityTypeBuilder<CurrencyDetail> builder)
        {
            builder.HasKey(c => new { c.CurrencyId, c.Date });

            builder.Property(x => x.CurrencyId).HasColumnOrder(1);

            builder.Property(x => x.Date)
                .HasColumnType("DATETIME")
                .HasColumnOrder(2);

            builder.Property(x => x.Value)
                .IsRequired(true)
                .HasColumnType("VARCHAR(10)")
                .HasColumnOrder(3);

            builder.HasOne(x => x.Currency) 
                .WithMany(x => x.CurrencyDetials)
                .HasForeignKey(x => x.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
