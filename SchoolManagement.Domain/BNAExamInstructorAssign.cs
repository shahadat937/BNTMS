using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaExamInstructorAssign : BaseDomainEntity
    {
        public BnaExamInstructorAssign()
        {
            BnaExamRoutineLogs = new HashSet<BnaExamRoutineLog>();
            TdecQuationGroups = new HashSet<TdecQuationGroup>();
            GuestSpeakerQuationGroups = new HashSet<GuestSpeakerQuationGroup>();
          //  GuestSpeakerQuestionNames = new HashSet<GuestSpeakerQuestionName>();
        }

        public int BnaExamInstructorAssignId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? ClassRoutineId { get; set; }
        public int? BnaInstructorTypeId { get; set; }        
        public int? TraineeId { get; set; }
        public string? ExamLocation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual BnaInstructorType? BnaInstructorType { get; set; }
        public virtual BnaSubjectName? BnaSubjectName { get; set; }
        public virtual ClassRoutine? ClassRoutine { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseModule? CourseModule { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual ICollection<BnaExamRoutineLog> BnaExamRoutineLogs { get; set; }
        public virtual ICollection<TdecQuationGroup> TdecQuationGroups { get; set; }
        public virtual ICollection<GuestSpeakerQuationGroup> GuestSpeakerQuationGroups { get; set; }
       /// public virtual ICollection<GuestSpeakerQuestionName> GuestSpeakerQuestionNames { get; set; }
    }
}
