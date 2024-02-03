namespace SchoolManagement.Application.DTOs.ClassPeriod
{
    public interface IClassPeriodDto
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
    }
}
  