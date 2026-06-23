using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Application.Interfaces.Persistence;
using ProductAPI.Infrastructure.Peristence.Context;
using ProductAPI.Infrastructure.Peristence.Repositories.Generic;
using ProductAPI.Infrastructure.Peristence.Repositories.Products;
using ProductAPI.Infrastructure.Peristence.UnitOfWork;
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

           
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;

        }
    }
}
