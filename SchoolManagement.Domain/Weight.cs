using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Weight : BaseDomainEntity
    {
        public Weight()
        {
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int WeightId { get; set; }
        public string WeightName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
