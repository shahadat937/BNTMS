using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class IndividualNotice : BaseDomainEntity 
    {  
        public int IndividualNoticeId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? Status { get; set; }
        public string? NoticeHeading { get; set; }
        public DateTime? EndDate { get; set; }
        public string? NoticeDetails { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }

        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseInstructor? CourseInstructor { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual TraineeNomination? TraineeNomination { get; set; } 
        public virtual BaseSchoolName? BaseSchoolName { get; set; } 
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; } 
    }
}
