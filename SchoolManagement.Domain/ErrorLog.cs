using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain
{
    public class ErrorLog
    {
        public int ErrorLogId { get; set; }
        public string? Subject { get; set; }
        public int? FailureCount { get; set; } 
        public string? FileUpload { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
