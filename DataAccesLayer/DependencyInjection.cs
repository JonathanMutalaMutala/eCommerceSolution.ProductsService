using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public static class DependencyInjection
    {
        public static  IServiceCollection AddDataAccessLayer(this IServiceCollection services)
        {
            //TO DO : Add Data access Layer services 


            return services; 
        }
    }
}
