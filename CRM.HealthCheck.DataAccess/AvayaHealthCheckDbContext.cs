using CRM.HealthCheck.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.HealthCheck.DataAccess
{
    public class AvayaHealthCheckDbContext : DbContext
    {
        public AvayaHealthCheckDbContext(DbContextOptions<AvayaHealthCheckDbContext> options)
            : base(options)
        {
        }

        public DbSet<LogEntity> Logs { get; set; }
    }
}
