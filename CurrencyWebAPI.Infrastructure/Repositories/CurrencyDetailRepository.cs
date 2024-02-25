using CurrencyWebAPI.Domain.Entities;
using CurrencyWebAPI.Domain.Repositories;
using CurrencyWebAPI.Infrastructure.AppDbContext;



namespace CurrencyWebAPI.Infrastructure.Repositories
{
    public class CurrencyDetailRepository : BaseRepository<CurrencyDetail>, ICurrencyDetailRepository
    {
        public CurrencyDetailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
