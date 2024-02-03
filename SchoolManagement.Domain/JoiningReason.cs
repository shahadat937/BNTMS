using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class JoiningReason :BaseDomainEntity
    {
        public int JoiningReasonId { get; set; }
        public int TraineeId { get; set; }
        public int ReasonTypeId { get; set; }
        public string? IfAnotherReason { get; set; }
        public string? AdditionlInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ReasonType ReasonType { get; set; } = null!;
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;
    }
}
