using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class District
    {
        public District()
        {
            BaseNames = new HashSet<BaseName>();
            EducationalInstitutions = new HashSet<EducationalInstitution>();
            FamilyInfos = new HashSet<FamilyInfo>();
            ParentRelatives = new HashSet<ParentRelative>();
            Thanas = new HashSet<Thana>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
        }

        public int DistrictId { get; set; }
        public int DivisionId { get; set; }
        public string DistrictName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Division Division { get; set; }
        public virtual ICollection<BaseName> BaseNames { get; set; }
        public virtual ICollection<EducationalInstitution> EducationalInstitutions { get; set; }
        public virtual ICollection<FamilyInfo> FamilyInfos { get; set; }
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
        public virtual ICollection<Thana> Thanas { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
    }
}
