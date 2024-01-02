using BarManagment.Domain.DomainEntities.Base;
using Microsoft.EntityFrameworkCore;

namespace BarManagment.Application.Core.Abstractions.Data
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>()
           where TEntity : BaseEntity;
    }
}
