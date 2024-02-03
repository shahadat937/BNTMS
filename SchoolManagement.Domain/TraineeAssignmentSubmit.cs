using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TraineeAssignmentSubmit:BaseDomainEntity
    {
        public TraineeAssignmentSubmit()
        {
            AssignmentMarkEntries = new HashSet<AssignmentMarkEntry>();


        }
        public int TraineeAssignmentSubmitId { get; set; }
        public int? InstructorAssignmentId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? InstructorId { get; set; }
        public int? TraineeId { get; set; }
        public string? AssignmentTopic { get; set; }
        public string? Remarks { get; set; }
        public string? ImageUpload { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual BnaSubjectName? BnaSubjectName { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseInstructor? CourseInstructor { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual TraineeBioDataGeneralInfo? Instructor { get; set; }
        public virtual InstructorAssignment? InstructorAssignment { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual ICollection<AssignmentMarkEntry> AssignmentMarkEntries { get; set; }
    }
}
