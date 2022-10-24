using Pacagroup.Ecommerce.Aplication.Validator;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.Validator
{
    public  static class ValidatorExtensions
    {
        public static IServiceCollection addValidator(this IServiceCollection services) 
        {
            services.AddTransient<UserDtoValidator>();
            return services;
        }
    }
}
