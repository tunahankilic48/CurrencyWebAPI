using CurrencyWebAPI.Domain.Entities;
using CurrencyWebAPI.Domain.Repositories;
using CurrencyWebAPI.Infrastructure.AppDbContext;

namespace CurrencyWebAPI.Infrastructure.Repositories
{
    public class CurrencyDetailHourlyRepository : BaseRepository<CurrencyDetailHourly>, ICurrencyDetailHourlyRepository
    {
        public CurrencyDetailHourlyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
