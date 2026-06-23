using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ProductAPI.Application.Features.Products.Mappings;
using ProductAPI.Application.Features.Products.Services;
using System.Reflection;

namespace ProductAPI.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();

            services.AddAutoMapper(cfg => { }, typeof(ProductMappingProfile));
            return services;
        }
    }
}
