using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CodeValue
    {
        public CodeValue()
        {
            BnaSemesterDurations = new HashSet<BnaSemesterDuration>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();
            FamilyNominations = new HashSet<FamilyNomination>();
            GrandFathers = new HashSet<GrandFather>();
            ParentRelatives = new HashSet<ParentRelative>();
            SwimmingDrivingLevels = new HashSet<SwimmingDrivingLevel>();
        }

        public int CodeValueId { get; set; }
        public int CodeValueTypeId { get; set; }
        public string Code { get; set; }
        public string TypeValue { get; set; }
        public string AdditonalValue { get; set; }
        public string DisplayCode { get; set; }
        public string Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual CodeValueType CodeValueType { get; set; }
        public virtual ICollection<BnaSemesterDuration> BnaSemesterDurations { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<FamilyNomination> FamilyNominations { get; set; }
        public virtual ICollection<GrandFather> GrandFathers { get; set; }
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
        public virtual ICollection<SwimmingDrivingLevel> SwimmingDrivingLevels { get; set; }
    }
}
