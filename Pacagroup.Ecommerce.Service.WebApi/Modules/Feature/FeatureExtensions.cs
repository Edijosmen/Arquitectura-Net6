namespace Pacagroup.Ecommerce.Service.WebApi.Modules.Feature
{
    public static class FeatureExtensions
    {
       
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            string myPolicy = "policyApiEcommerce";
            services.AddCors(options =>
                         options.AddPolicy(myPolicy, Policybuilder =>
                                                     Policybuilder.WithOrigins(configuration["ConfigCors:OriginCors"])
                                                                   .AllowAnyHeader()
                                                                   .AllowAnyMethod()));
            return services;
        }
    }
}
