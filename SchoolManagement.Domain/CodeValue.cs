using SchoolManagement.Domain.Common;


namespace SchoolManagement.Domain
{
    public class CodeValue : BaseDomainEntity
    {
        public CodeValue()
        {
            BnaSemesterDurations = new HashSet<BnaSemesterDuration>();
            FamilyNominations = new HashSet<FamilyNomination>();
            GrandFathers = new HashSet<GrandFather>();
            SwimmingDrivingLevels = new HashSet<SwimmingDrivingLevel>();
            ParentRelatives = new HashSet<ParentRelative>();
        }

        public int CodeValueId { get; set; }
        public int CodeValueTypeId { get; set; }
        public string Code { get; set; } = null!;
        public string? TypeValue { get; set; }
        public string? AdditonalValue { get; set; }
        public string? DisplayCode { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public virtual CodeValueType CodeValueType { get; set; } = null!;
        public virtual ICollection<BnaSemesterDuration> BnaSemesterDurations { get; set; }
        public virtual ICollection<FamilyNomination> FamilyNominations { get; set; }
        public virtual ICollection<GrandFather> GrandFathers { get; set; }
        public virtual ICollection<SwimmingDrivingLevel> SwimmingDrivingLevels { get; set; }
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }

    }
}
