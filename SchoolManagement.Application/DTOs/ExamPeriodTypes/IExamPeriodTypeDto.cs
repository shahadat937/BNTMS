using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ExamPeriodTypes 
{
    public interface IExamPeriodTypeDto 
    {
        public int ExamPeriodTypeId { get; set; }
        public string? ExamPeriodName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    } 
}
