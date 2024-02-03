using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ColorOfEye : BaseDomainEntity
    {
        public ColorOfEye()
        {
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int ColorOfEyeId { get; set; }
        public string ColorOfEyeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
