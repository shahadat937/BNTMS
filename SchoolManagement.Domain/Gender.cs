using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Gender : BaseDomainEntity
    {
        public Gender()
        {
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            FamilyInfos = new HashSet<FamilyInfo>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<FamilyInfo> FamilyInfos { get; set; }
    }
}
