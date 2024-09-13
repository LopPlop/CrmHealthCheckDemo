using CRM.HealthCheck.BusinessLogic.Service;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CRM.HealthCheck.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly HealthCheckService _healthCheckService;
        private readonly ISendMailService _sendMailService;

        public HealthCheckController(HealthCheckService healthCheckService, ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
            _healthCheckService = healthCheckService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _sendMailService.SendMailAsync("pochta32pochta@gmail.com", "0", "0");

            HealthReport healthReport = await _healthCheckService.CheckHealthAsync();
            return Ok(healthReport.Status.ToString());
        }
    }
}
