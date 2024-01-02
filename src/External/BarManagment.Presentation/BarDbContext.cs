using BarManagment.Application.Core.Abstractions.Data;
using BarManagment.Domain.DomainEntities.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BarManagment.Presentation
{
    public class BarDbContext : DbContext, IDbContext
    {
        public BarDbContext(DbContextOptions options) : base(options) { }
        public new DbSet<TEntity> Set<TEntity>()
            where TEntity : BaseEntity
            => base.Set<TEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
