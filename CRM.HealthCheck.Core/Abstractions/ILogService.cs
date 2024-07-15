using CRM.HealthCheck.Core.Models;

namespace CRM.HealthCheck.BusinessLogic.Service
{
    public interface ILogService
    {
        Task<int> CreateLog(Log log);
        Task<int> DeleteLog(int id);
        Task<List<Log>> ReadLog();
        Task<int> UpdateLog(Log log);
    }
}