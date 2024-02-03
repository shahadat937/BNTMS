using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ExamMarkRemarks
{
    public class ExamMarkRemarkDto : IExamMarkRemarkDto
    {
        public int ExamMarkRemarksId { get; set; }
        public string? MarkRemark { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
