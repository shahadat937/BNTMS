using SchoolManagement.Domain.Common;



namespace SchoolManagement.Domain
{
    public class Nationality : BaseDomainEntity
    {
        public Nationality()
        {
            GrandFathers = new HashSet<GrandFather>();
            ParentRelativeNationalities = new HashSet<ParentRelative>();
            ParentRelativeSecondNationalities = new HashSet<ParentRelative>();
            TraineeBioDataGeneralInfoNationalities = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            FamilyInfos = new HashSet<FamilyInfo>();
        }

        public int NationalityId { get; set; }
        public string NationalityName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<GrandFather> GrandFathers { get; set; }

        public virtual ICollection<ParentRelative> ParentRelativeNationalities { get; set; }
        public virtual ICollection<ParentRelative> ParentRelativeSecondNationalities { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoNationalities { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<FamilyInfo> FamilyInfos { get; set; }
    }
}
