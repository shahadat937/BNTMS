namespace SchoolManagement.Application.DTOs.ClassPeriod
{
    public class ClassPeriodDto : IClassPeriodDto
    {
        public int ClassPeriodId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BnaClassScheduleStatusId { get; set; }
        public string? PeriodName { get; set; }
        public string? DurationForm { get; set; }
        public string? DurationTo { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? BaseSchoolName { get; set; }
        public string? CourseName { get; set; }
        public string? BnaClassScheduleStatus { get; set; }
    }
}
 