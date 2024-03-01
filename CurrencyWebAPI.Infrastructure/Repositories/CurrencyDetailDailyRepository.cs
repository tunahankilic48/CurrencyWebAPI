using CurrencyWebAPI.Domain.Entities;
using CurrencyWebAPI.Domain.Repositories;
using CurrencyWebAPI.Infrastructure.AppDbContext;

namespace CurrencyWebAPI.Infrastructure.Repositories
{
    public class CurrencyDetailDailyRepository : BaseRepository<CurrencyDetailDaily>, ICurrencyDetailDailyRepository
    {
        public CurrencyDetailDailyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
