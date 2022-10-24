using Microsoft.AspNetCore.Connections;
using Pacagroup.Ecommerce.Aplication.Interface;
using Pacagroup.Ecommerce.Aplication.main;
using Pacagroup.Ecommerce.Domain.Core;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructura.Data;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using Pacagroup.Ecommerce.Infrastructure.Repository;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Transversal.logging;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<ICustomersAplication, CustomersApplication>();
            services.AddScoped<ICustomerDomain, CustomersDomain>();
            services.AddScoped<ICustomerRepository, CustomersRepository>();
            services.AddScoped<IUserAplication, UserAplication>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
