using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Country : BaseDomainEntity
    {
        public Country()
        {
            CourseDurations = new HashSet<CourseDuration>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            TraineeVisitedAboards = new HashSet<TraineeVisitedAboard>();
            AllowanceCategories = new HashSet<AllowanceCategory>();
            CurrencyNames = new HashSet<CurrencyName>();
            Allowances = new HashSet<Allowance>();
            InterServiceMarks = new HashSet<InterServiceMark>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
        }

        public int CountryId { get; set; }
        public int? CountryGroupId { get; set; }
        public int? CurrencyNameId { get; set; }
        public string CountryName { get; set; } = null!;
        public int? CurrentPrice { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CountryGroup? CountryGroup { get; set; }
        public virtual CurrencyName? CurrencyName { get; set; }
        public virtual ICollection<CourseDuration> CourseDurations { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<TraineeVisitedAboard> TraineeVisitedAboards { get; set; }
        public virtual ICollection<AllowanceCategory> AllowanceCategories { get; set; }
        public virtual ICollection<CurrencyName> CurrencyNames { get; set; }
        public virtual ICollection<Allowance> Allowances { get; set; }
        public virtual ICollection<InterServiceMark> InterServiceMarks { get; set; }
    }
}
