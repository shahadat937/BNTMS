using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;
 
namespace SchoolManagement.Domain
{
    public class GuestSpeakerQuationGroup : BaseDomainEntity
    {
        public int GuestSpeakerQuationGroupId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaExamInstructorAssignId { get; set; }
        public int? TraineeId { get; set; }
        public int? GuestSpeakerQuestionNameId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual BnaExamInstructorAssign? BnaExamInstructorAssign { get; set; }
        public virtual BnaSubjectName? BnaSubjectName { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual GuestSpeakerQuestionName? GuestSpeakerQuestionName { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
    }
}
