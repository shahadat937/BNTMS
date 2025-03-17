using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ErrorLog
{
    public class CreateErrorLogDto : IErrorLogDto
    {
        public int ErrorLogId { get; set; }
        public string? Subject { get; set; }
        public int? FailureCount { get; set; }
        public string? FileUpload { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
