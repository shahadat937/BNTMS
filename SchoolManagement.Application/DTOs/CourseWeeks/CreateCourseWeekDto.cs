using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseWeeks
{
    public class CreateCourseWeekDto : ICourseWeekDto  
    {
        public int CourseWeekId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? WeekName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
