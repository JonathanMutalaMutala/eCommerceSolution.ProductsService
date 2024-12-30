using eCommerce.DataAccesLayer.Context;
using eCommerce.DataAccesLayer.Repositories;
using eCommerce.DataAccesLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccesLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //TO DO : Add Data access Layer services 

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySQL(configuration.GetConnectionString("DefaultConnection")!);
            });
            services.AddScoped<IProductRepository, ProductRepository>(); 

            return services; 
        }
    }
}
