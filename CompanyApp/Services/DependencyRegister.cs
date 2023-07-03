using Domain.DTOS;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using Services.Interfaces;
using Services.Mappers;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static  class DependencyRegister
    {
        public static void Register(IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<ICountryService, CountryService>();

            services.AddTransient<IValidator<CompanyDto>, CompanyValidator>();
            services.AddTransient<IValidator<ContactDto>, ContactValidator>();
            services.AddTransient<IValidator<CountryDto>, CountryValidator>();
        }
    }
}
