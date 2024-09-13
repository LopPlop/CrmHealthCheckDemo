using CRM.HealthCheck.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRM.HealthCheck.DataAccess
{
    public class CRMHealthCheckDbContext : DbContext
    {
        public CRMHealthCheckDbContext(DbContextOptions<CRMHealthCheckDbContext> options)
            : base(options)
        {
        }
        public DbSet<LogEntity> Logs {  get; set; }
    }
}
