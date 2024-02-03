using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Caste : BaseDomainEntity
    {
        public Caste()
        {
            ParentRelatives = new HashSet<ParentRelative>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            FamilyInfos = new HashSet<FamilyInfo>();
        }

        public int CasteId { get; set; }
        public int ReligionId { get; set; }
        public string CastName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Religion Religion { get; set; } = null!;
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<FamilyInfo> FamilyInfos { get; set; }
    }
}
