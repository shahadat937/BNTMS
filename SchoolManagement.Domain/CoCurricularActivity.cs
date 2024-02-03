using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CoCurricularActivity : BaseDomainEntity
    {
        public int CoCurricularActivityId { get; set; }
        public int TraineeId { get; set; }
        public int CoCurricularActivityTypeId { get; set; }
        public string? Participation { get; set; }
        public string? Achievement { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CoCurricularActivityType CoCurricularActivityType { get; set; } = null!;
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;

    }
}
