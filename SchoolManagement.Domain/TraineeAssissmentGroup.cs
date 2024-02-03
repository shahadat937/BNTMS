using SchoolManagement.Domain.Common;


namespace SchoolManagement.Domain
{
    public class TraineeAssissmentGroup : BaseDomainEntity
    {
        public int TraineeAssissmentGroupId { get; set; }
        public int? TraineeAssissmentCreateId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public string? AssissmentGroupName { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual TraineeAssessmentCreate? TraineeAssissmentCreate { get; set; }
        public virtual TraineeNomination? TraineeNomination { get; set; }
    }
}
