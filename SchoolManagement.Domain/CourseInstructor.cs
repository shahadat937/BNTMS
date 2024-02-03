using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CourseInstructor: BaseDomainEntity
    {
        public CourseInstructor()
        {
            Notices = new HashSet<Notice>();
            IndividualBulletins = new HashSet<IndividualBulletin>();
            IndividualNotices = new HashSet<IndividualNotice>();
            InstructorAssignments = new HashSet<InstructorAssignment>();
            TraineeAssignmentSubmits = new HashSet<TraineeAssignmentSubmit>();
        }
        public int CourseInstructorId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? DepartmentId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? TraineeId { get; set; }
        public int? SubjectMarkId { get; set; }
        public int? MarkTypeId { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }
        public int? ExamMarkEntry { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual BnaSubjectName? BnaSubjectName { get; set; }
        public virtual BnaSemester? BnaSemester { get; set; }
        public virtual Department? Department { get; set; }
        public virtual BnaSubjectCurriculum? BnaSubjectCurriculum { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseModule? CourseModule { get; set; }
        public virtual MarkType? MarkType { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<IndividualBulletin> IndividualBulletins { get; set; }
        public virtual ICollection<IndividualNotice> IndividualNotices { get; set; }
        public virtual ICollection<InstructorAssignment> InstructorAssignments { get; set; }
        public virtual ICollection<TraineeAssignmentSubmit> TraineeAssignmentSubmits { get; set; }
    }
}
