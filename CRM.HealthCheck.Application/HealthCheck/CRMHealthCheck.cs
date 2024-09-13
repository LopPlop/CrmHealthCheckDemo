using CRM.HealthCheck.BusinessLogic.Service;
using CRM.HealthCheck.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CRM.HealthCheck.Application.HealthCheck
{
    public class CRMHealthCheck : IHealthCheck
    {
        private static DateTime timeMailSended = DateTime.MinValue;
        private readonly ISendMailService _sendMailService;
        private readonly CRMHealthCheckDbContext _contextCRM;
        public CRMHealthCheck(ISendMailService sendMailService, CRMHealthCheckDbContext context)
        {
            _contextCRM = context;
            _sendMailService = sendMailService;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (!_contextCRM.Database.CanConnect())
            {
                if ((DateTime.Now.Subtract(timeMailSended)).TotalMinutes > 5) await _sendMailService.SendMailAsync("pochta32pochta@gmail.com", "0", "0");

                timeMailSended = DateTime.Now;

                return await Task.FromResult(new HealthCheckResult(
                        status: HealthStatus.Unhealthy,
                        description: "DataBase is working uncorrectly.")
                    );
            }

            return await Task.FromResult(new HealthCheckResult(
                status: HealthStatus.Healthy,
                description: "DataBase is working correctly."));
        }
    }
}
