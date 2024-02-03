using SchoolManagement.Domain.Common;
using System; 
using System.Collections.Generic;

namespace SchoolManagement.Domain
{
    public class GuestSpeakerGroupResult:BaseDomainEntity
    {
        public int GuestSpeakerGroupResultId { get; set; }
        public int? GuestSpeakerQuationGroupId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaExamInstructorAssignId { get; set; }
        public int? InstructorId { get; set; }
        public int? GuestSpeakerQuestionNameId { get; set; }
        public int GuestSpeakerActionStatusId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual GuestSpeakerActionStatus? GuestSpeakerActionStatus { get; set; }
        public virtual GuestSpeakerQuationGroup? GuestSpeakerQuationGroup { get; set; }
        public virtual TraineeNomination? TraineeNomination { get; set; }
    }
}
