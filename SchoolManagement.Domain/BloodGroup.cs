using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BloodGroup : BaseDomainEntity
    {
        public BloodGroup()
        {
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int BloodGroupId { get; set; }
        public string BloodGroupName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
