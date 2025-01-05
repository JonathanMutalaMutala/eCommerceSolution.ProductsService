using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperProfile).Assembly);
            services.AddScoped<IProductService, ProductService>();
            services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();
            return services;
        }
    }
}
