using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Infrastructure.Peristence.Context;
using System.Reflection;

namespace ProductAPI.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
           
            var connectionString = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString!, sqlServerOptionsAction =>
                {
                  
                    sqlServerOptionsAction.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                });
            });

            ///TODO :DI kontrol et.Repo,UnitOfWork

            return services;

        }
    }
}
