using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ErrorLog
{
    public interface IErrorLogDto
    {
        public int ErrorLogId { get; set; }
        public string? Subject { get; set; }
        public int? FailureCount { get; set; }
        public string? FileUpload { get; set; }
        public DateTime? CreatedDate { get; set; }
    } 
}
