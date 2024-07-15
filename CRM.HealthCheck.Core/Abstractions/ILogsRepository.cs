using CRM.HealthCheck.Core.Models;

namespace CRM.HealthCheck.DataAccess.Repository
{
    public interface ILogsRepository
    {
        Task<int> Create(Log log);
        Task<int> Delete(int id);
        Task<List<Log>> Read();
        Task<int> Update(Log entity);
    }
}