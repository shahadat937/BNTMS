using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class District : BaseDomainEntity
    {
        public District()
        {
            BaseNames = new HashSet<BaseName>();
            EducationalInstitutions = new HashSet<EducationalInstitution>();
            ParentRelatives = new HashSet<ParentRelative>();
            Thanas = new HashSet<Thana>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            FamilyInfos = new HashSet<FamilyInfo>();
        }

        public int DistrictId { get; set; }
        public int DivisionId { get; set; }
        public string DistrictName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Division Division { get; set; } = null!;
        public virtual ICollection<BaseName> BaseNames { get; set; }
        public virtual ICollection<EducationalInstitution> EducationalInstitutions { get; set; }
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
        public virtual ICollection<Thana> Thanas { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<FamilyInfo> FamilyInfos { get; set; }
    }
}
