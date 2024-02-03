using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Thana : BaseDomainEntity
    {
        public Thana()
        {
            EducationalInstitutions = new HashSet<EducationalInstitution>();
            ParentRelatives = new HashSet<ParentRelative>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            FamilyInfos = new HashSet<FamilyInfo>();
        }

        public int ThanaId { get; set; }
        public int DistrictId { get; set; }
        public string ThanaName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual District District { get; set; } = null!;
        public virtual ICollection<EducationalInstitution> EducationalInstitutions { get; set; }
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<FamilyInfo> FamilyInfos { get; set; }
    }
}
