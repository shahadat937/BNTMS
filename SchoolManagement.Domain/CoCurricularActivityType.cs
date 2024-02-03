using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CoCurricularActivityType : BaseDomainEntity
    {
        public CoCurricularActivityType()
        {
            CoCurricularActivities = new HashSet<CoCurricularActivity>();
        }

        public int CoCurricularActivityTypeId { get; set; }
        public string CoCurricularActivityName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CoCurricularActivity> CoCurricularActivities { get; set; }
    }
}
