using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class InstructorAssignment:BaseDomainEntity
    {
        public InstructorAssignment()
        {
            TraineeAssignmentSubmits = new HashSet<TraineeAssignmentSubmit>();
        }
        public int InstructorAssignmentId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? InstructorId { get; set; }
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
        public virtual BnaSubjectName? BnaSubjectName { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseInstructor? CourseInstructor { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual ICollection<TraineeAssignmentSubmit> TraineeAssignmentSubmits { get; set; }
    }
}
