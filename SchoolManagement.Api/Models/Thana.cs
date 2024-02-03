using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Thana
    {
        public Thana()
        {
            EducationalInstitutions = new HashSet<EducationalInstitution>();
            FamilyInfos = new HashSet<FamilyInfo>();
            ParentRelatives = new HashSet<ParentRelative>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
        }

        public int ThanaId { get; set; }
        public int DistrictId { get; set; }
        public string ThanaName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual District District { get; set; }
        public virtual ICollection<EducationalInstitution> EducationalInstitutions { get; set; }
        public virtual ICollection<FamilyInfo> FamilyInfos { get; set; }
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
    }
}
