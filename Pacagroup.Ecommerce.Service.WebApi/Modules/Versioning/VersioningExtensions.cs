using Microsoft.AspNetCore.Mvc.Versioning;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.Versioning
{
    public  static class VersioningExtensions
    {
        public static  IServiceCollection AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(v =>
            {
                v.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                v.AssumeDefaultVersionWhenUnspecified = true;
                v.ReportApiVersions = true;
                v.ApiVersionReader = new QueryStringApiVersionReader("api-version");
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat ="'v'VVV";
            });
            return services;
        }
    }
}
