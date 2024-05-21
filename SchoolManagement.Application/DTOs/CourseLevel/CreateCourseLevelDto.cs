using System;

namespace SchoolManagement.Application.DTOs.CourseLevel
{
    public class CreateCourseLevelDto : ICourseLevelDto
    {
        public int CourseLevelId { get; set; }
        public string CourseLeveTitle { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
