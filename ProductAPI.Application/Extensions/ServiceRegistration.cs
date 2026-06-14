using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Application.Features.Products.Mappings;
using System.Reflection;

namespace ProductAPI.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
         
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
           
            services.AddAutoMapper(cfg => { }, typeof(ProductMappingProfile));
            return services;
        }
    }
}
