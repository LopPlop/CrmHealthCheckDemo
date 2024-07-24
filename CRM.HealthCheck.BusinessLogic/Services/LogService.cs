using CRM.HealthCheck.Core.Models;
using CRM.HealthCheck.DataAccess.Repository;
using System.Diagnostics.Metrics;

namespace CRM.HealthCheck.BusinessLogic.Service
{
    public class LogService : ILogService
    {
        private readonly ILogsRepository _logsRepository;

        public LogService(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public async Task<int> CreateLog(Log log) => await _logsRepository.Create(log);

        public async Task<List<Log>> ReadLog() => await _logsRepository.Read();

        public async Task<int> UpdateLog(Log log) => await _logsRepository.Update(log);

        public async Task<int> DeleteLog(int id) => await _logsRepository.Delete(id);
    }
}
