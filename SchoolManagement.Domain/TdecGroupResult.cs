﻿using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TdecGroupResult : BaseDomainEntity
    {
        public int TdecGroupResultId { get; set; }
        public int? TdecQuationGroupId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaExamInstructorAssignId { get; set; }
        public int? InstructorId { get; set; }
        public int? TdecQuestionNameId { get; set; }
        public int? TdecActionStatusId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual TdecActionStatus? TdecActionStatus { get; set; }
        public virtual TdecQuationGroup? TdecQuationGroup { get; set; }
        public virtual TraineeNomination? TraineeNomination { get; set; }
    }
}
