namespace SchoolManagement.Application.DTOs.InstructorAssignments
{
    public interface IInstructorAssignmentDto
    {
        public int InstructorAssignmentId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public string? AssignmentTopic { get; set; }
        public string? Remarks { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? AssignmentMark { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
