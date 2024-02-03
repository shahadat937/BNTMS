using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class HairColor : BaseDomainEntity
    {
        public HairColor()
        {
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
        }

        public int HairColorId { get; set; }
        public string HairColorName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
    }
}
