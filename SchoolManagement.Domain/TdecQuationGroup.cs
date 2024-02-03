using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TdecQuationGroup : BaseDomainEntity
    {

        public TdecQuationGroup()
        {
            TdecGroupResults = new HashSet<TdecGroupResult>();
        }
        public int TdecQuationGroupId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaExamInstructorAssignId { get; set; } 
        public int? TraineeId { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Status { get; set; }
        public int? TdecQuestionNameId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual BnaSubjectName? BnaSubjectName { get; set; }
        public virtual BnaExamInstructorAssign? BnaExamInstructorAssign { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual TdecQuestionName? TdecQuestionName { get; set; }

        public virtual ICollection<TdecGroupResult> TdecGroupResults { get; set; }
    }
}
