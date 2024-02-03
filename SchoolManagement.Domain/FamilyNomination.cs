using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class FamilyNomination : BaseDomainEntity
    {
        public int FamilyNominationId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeId { get; set; }
        public int? FamilyInfoId { get; set; }
        public int? FundingDetailId { get; set; }
        public int? RelationTypeId { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CodeValue? FundingDetail { get; set; }
        public virtual FamilyInfo? FamilyInfo { get; set; }
        public virtual RelationType? RelationType { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual TraineeNomination? TraineeNomination { get; set; }
    }
}
