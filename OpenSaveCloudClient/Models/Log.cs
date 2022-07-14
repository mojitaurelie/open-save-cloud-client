using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSaveCloudClient.Models
{
    public enum LogSeverity
    {
        Error,
        Warning,
        Information
    }

    public class Log
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public LogSeverity Severity { get; set; }
    }
}
