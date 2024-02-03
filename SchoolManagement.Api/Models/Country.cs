using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Country
    {
        public Country()
        {
            AllowanceCategories = new HashSet<AllowanceCategory>();
            Allowances = new HashSet<Allowance>();
            CourseDurations = new HashSet<CourseDuration>();
            CurrencyNames = new HashSet<CurrencyName>();
            InterServiceMarks = new HashSet<InterServiceMark>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            TraineeVisitedAboards = new HashSet<TraineeVisitedAboard>();
        }

        public int CountryId { get; set; }
        public int? CountryGroupId { get; set; }
        public int? CurrencyNameId { get; set; }
        public string CountryName { get; set; }
        public int? CurrentPrice { get; set; }
        public string ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual CountryGroup CountryGroup { get; set; }
        public virtual CurrencyName CurrencyName { get; set; }
        public virtual ICollection<AllowanceCategory> AllowanceCategories { get; set; }
        public virtual ICollection<Allowance> Allowances { get; set; }
        public virtual ICollection<CourseDuration> CourseDurations { get; set; }
        public virtual ICollection<CurrencyName> CurrencyNames { get; set; }
        public virtual ICollection<InterServiceMark> InterServiceMarks { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<TraineeVisitedAboard> TraineeVisitedAboards { get; set; }
    }
}
