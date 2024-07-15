using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CRM.HealthCheck.Application.HealthCheck
{
    public class CRMHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(new HealthCheckResult(
                status: HealthStatus.Healthy,
                description: "DataBase is working correctly."));
        }
    }
}
