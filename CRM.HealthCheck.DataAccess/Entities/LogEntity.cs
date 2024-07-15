using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.HealthCheck.DataAccess.Entities
{
    public class LogEntity
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? Description { get; set; }
        public DateTime? Time { get; set; }
        public string? Status { get; set; }
    }
}
