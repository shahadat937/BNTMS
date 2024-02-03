using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.InterServiceCourseReport
{
    public class InterServiceCourseReportDto : IInterServiceCourseReportDto
    {
        public int InterServiceCourseReportid { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? TraineeId { get; set; }
        public string? Remarks { get; set; }
        public string? Doc { get; set; }
        public bool IsActive { get; set; }

        public string? CourseDuration { get; set; }
    }
}
