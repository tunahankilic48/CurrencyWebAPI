using CurrencyWebAPI.Domain.Entities;
using CurrencyWebAPI.Domain.Repositories;
using CurrencyWebAPI.Infrastructure.AppDbContext;


namespace CurrencyWebAPI.Infrastructure.Repositories
{
    public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
