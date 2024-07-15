using Microsoft.EntityFrameworkCore;
using CRM.HealthCheck.Core.Models;
using CRM.HealthCheck.DataAccess.Entities;

namespace CRM.HealthCheck.DataAccess.Repository
{
    public class LogsRepository : ILogsRepository
    {
        private CRMHealthCheckDbContext _context;

        public LogsRepository(CRMHealthCheckDbContext context) => _context = context;

        public async Task<int> Create(Log log)
        {
            var logEntity = new LogEntity()
            {
                Message = log.Message,
                Description = log.Description,
                Time = log.Time,
                Status = log.Status
            };


            await _context.Logs
                .AddAsync(logEntity);

            _context.SaveChanges();

            return logEntity.Id;
        }
        public async Task<List<Log>> Read()
        {
            var logEntities = await _context.Logs
                .ToListAsync();

            var logs = logEntities.Select(l => new Log(l.Id, l.Message, l.Description, l.Time.Value, l.Status))
                .ToList();

            return logs;
        }

        public async Task<int> Update(Log entity)
        {
            var temp = await _context.Logs.Where(e => e.Id == entity.Id).FirstAsync();

            if (temp is not null)
            {
                await _context.Logs
                    .Where(e => e.Id == entity.Id)
                    .ExecuteUpdateAsync(i => i
                        .SetProperty(p => p.Message, entity.Message)
                        .SetProperty(p => p.Description, entity.Description)
                        .SetProperty(p => p.Time, entity.Time)
                        .SetProperty(p => p.Status, entity.Status));

                _context.SaveChanges();
            }

            return entity.Id;
        }

        public async Task<int> Delete(int id)
        {
            await _context.Logs
                .Where(e => e.Id == id)
                .ExecuteDeleteAsync();

            _context.SaveChanges();

            return id;
        }
    }
}
