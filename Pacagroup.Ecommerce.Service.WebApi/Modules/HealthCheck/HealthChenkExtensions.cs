namespace Pacagroup.Ecommerce.Service.WebApi.Modules.HealthCheck
{
    public static class HealthChenkExtensions
    {
        public static IServiceCollection AddHealtCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks().AddSqlServer(configuration.GetConnectionString("cnn_sqlSserver"), tags:new[] {"database","correcto"});
            services.AddHealthChecksUI().AddInMemoryStorage();
            return services;
        }
    }
}
