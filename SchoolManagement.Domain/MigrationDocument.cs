using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class MigrationDocument : BaseDomainEntity
    {
        public int MigrationDocumentId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public int? RelationTypeId { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual RelationType? RelationType { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual TraineeNomination? TraineeNomination { get; set; }
    }
}
