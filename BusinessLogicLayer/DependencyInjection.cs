﻿using BusinessLogicLayer.Mappers;
using BusinessLogicLayer.ServiceContracts;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
