using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Pacagroup.Ecommerce.Service.WebApi.Modules.HealthCheck
{
    public class HealthCheckCustomer : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }   
    }
}
