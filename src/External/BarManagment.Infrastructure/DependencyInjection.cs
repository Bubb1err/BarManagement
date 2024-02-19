using BarManagment.Application.Core.Abstractions.Authentication;
using BarManagment.Application.Core.Abstractions.Common;
using BarManagment.Application.Core.Abstractions.Cryptography;
using BarManagment.Domain.Services;
using BarManagment.Infrastructure.Authentication;
using BarManagment.Infrastructure.Authentication.Settings;
using BarManagment.Infrastructure.Common;
using BarManagment.Infrastructure.Cryptography;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BarManagment.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"]))
                });

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingsKey));

            services.AddScoped<IJwtProvider, JwtProvider>();

            services.AddTransient<IPasswordHasher, PasswordHasher>();

            services.AddTransient<IPasswordHashChecker, PasswordHasher>();

            services.AddTransient<IDateTime, MachineDateTime>();

            return services;
        }
    }
}
