namespace SchoolManagement.Application.DTOs.CourseLevel
{
    public class CourseLevelDto : ICourseLevelDto
    {
        public int CourseLevelId { get; set; }
        public string CourseLeveTitle { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
