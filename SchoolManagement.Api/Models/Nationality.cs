using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Nationality
    {
        public Nationality()
        {
            FamilyInfos = new HashSet<FamilyInfo>();
            GrandFathers = new HashSet<GrandFather>();
            ParentRelativeNationalities = new HashSet<ParentRelative>();
            ParentRelativeSecondNationalities = new HashSet<ParentRelative>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int NationalityId { get; set; }
        public string NationalityName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<FamilyInfo> FamilyInfos { get; set; }
        public virtual ICollection<GrandFather> GrandFathers { get; set; }
        public virtual ICollection<ParentRelative> ParentRelativeNationalities { get; set; }
        public virtual ICollection<ParentRelative> ParentRelativeSecondNationalities { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
