using BarManagment.Domain.Abstractions.Repository.Base;
using BarManagment.Domain.DomainEntities;
using BarManagment.Presentation.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarManagment.Presentation
{
    public static class DependencyInjection
    {
        private static string _connectionStringKey = "SqlConnection";
        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(_connectionStringKey);

            services.AddDbContext<BarDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IRepository<Commodity>, BaseRepository<Commodity>>();
            services.AddScoped<IRepository<DefaultMeasure>, BaseRepository<DefaultMeasure>>();
            services.AddScoped<IRepository<Coctail>, BaseRepository<Coctail>>();
            services.AddScoped<IRepository<CoctailIngredient>, BaseRepository<CoctailIngredient>>();
            services.AddScoped<IRepository<Drink>, BaseRepository<Drink>>();

            return services;
        }
    }
}
