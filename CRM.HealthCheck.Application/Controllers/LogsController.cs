using CRM.HealthCheck.Application.Contracts;
using CRM.HealthCheck.BusinessLogic.Service;
using CRM.HealthCheck.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CRM.HealthCheck.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogsController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LogsResponse>>> GetLogs()
        {
            var logs = await _logService.ReadLog();

            var response = logs.Select(l => new LogsResponse(l.Id, l.Message, l.Description, l.Time.Value, l.Status));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateLogs([FromBody] LogsRequest request)
        {
            var logs = await _logService.ReadLog();

            var newLog = new Log(request.Message, request.Description, request.Time, request.Status);

            var logId = await _logService.CreateLog(newLog);

            return Ok(logId);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateLog(int id, [FromBody] LogsRequest request)
        {
            var updatedLog = new Log(id, request.Message, request.Description, request.Time, request.Status);

            var logId = await _logService.UpdateLog(updatedLog);

            return Ok(logId);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteLog(int id)
        {
            return Ok(await _logService.DeleteLog(id));
        }
    }
}
