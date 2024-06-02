using BarManagment.Domain.Abstractions.Repository;
using BarManagment.Domain.DomainEntities;
using BarManagment.Domain.Models.Buyings;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Persistance.Repositories
{
    public class BuyingsRepository : BaseRepository<Buying>, IBuyingsRepository
    {
        public BuyingsRepository(BarDbContext context) : base(context)
        {
        }

        public async Task<double> GetLeftAmount(Guid commodityId)
        {
            var previousBuying = await _dbSet
                .Where(buying => buying.CommodityId == commodityId)
                .OrderByDescending(buying => buying.PurchaseDate)
                .Skip(1)
                .Take(1)
                .SingleOrDefaultAsync();

            if (previousBuying is not null)
            {
                return previousBuying.AvailableAmount >= 0 ? previousBuying.AvailableAmount : 0;
            }
            return 0;
        }

        public async Task<Buying?> GetLastBuying(Guid commodityId)
        {
            var buying = await _dbSet
               .Where(buying => buying.CommodityId == commodityId)
               .OrderByDescending(buying => buying.PurchaseDate)
               .Take(1)
               .SingleOrDefaultAsync();

            return buying;
        }

        public IQueryable<SpendingViewModel> GetSpendings(string companyCode)
        {
            var spendings = _context.Database
                .SqlQuery<SpendingViewModel>($@"EXEC [dbo].[GetSpendings] @companyCode={companyCode}");

            return spendings;
        }
    }
}
