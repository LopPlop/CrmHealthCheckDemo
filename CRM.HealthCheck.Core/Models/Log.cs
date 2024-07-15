
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.HealthCheck.Core.Models
{
    public class Log
    {
        public Log(int id, string message, string description, DateTime time, string status)
        {
            Id = id;
            Message = message;
            Description = description;
            Time = time;
            Status = status;
        }
        
        public Log(string message, string description, DateTime time, string status)
        {
            Message = message;
            Description = description;
            Time = time;
            Status = status;
        }

        public int Id { get; }
        public string? Message { get; }
        public string? Description { get; }
        public DateTime? Time { get; }
        public string? Status { get; }

    }
}
