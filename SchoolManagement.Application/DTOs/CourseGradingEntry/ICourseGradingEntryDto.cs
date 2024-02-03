using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseGradingEntry
{
    public interface ICourseGradingEntryDto
    {
        public int CourseGradingEntryId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? AssessmentId { get; set; }
        public double? MarkObtained { get; set; }
        public string? Grade { get; set; }
        public string? MarkFrom { get; set; }
        public string? MarkTo { get; set; }
        public bool IsActive { get; set; }
    }
}
