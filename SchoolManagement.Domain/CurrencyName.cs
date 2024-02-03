﻿using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CurrencyName : BaseDomainEntity
    {
        public CurrencyName()
        {
           
            Countries = new HashSet<Country>();
            AllowanceCategories = new HashSet<AllowanceCategory>();
        }

        public int CurrencyNameId { get; set; }
        public int? CountryId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<AllowanceCategory> AllowanceCategories { get; set; }

    }
}
