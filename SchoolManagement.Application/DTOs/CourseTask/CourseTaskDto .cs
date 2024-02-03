using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseTask
{
    public class CourseTaskDto : ICourseTaskDto
    {
        public int CourseTaskId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public string? TaskDetail { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? SchoolName { get; set; }
        public string? CourseName { get; set; }
        public string? SubjectName { get; set; }
    }
}
