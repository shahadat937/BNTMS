namespace SchoolManagement.Application.DTOs.Event
{
    public interface IEventDto
    {
        public int EventId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? Status { get; set; }
        public string? EventHeading { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? EventDetails { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
  