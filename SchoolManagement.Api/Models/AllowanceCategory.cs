using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AllowanceCategory
    {
        public AllowanceCategory()
        {
            Allowances = new HashSet<Allowance>();
        }

        public int AllowanceCategoryId { get; set; }
        public int? FromRankId { get; set; }
        public int? ToRankId { get; set; }
        public int? CountryGroupId { get; set; }
        public int? CountryId { get; set; }
        public int? CurrencyNameId { get; set; }
        public int? AllowancePercentageId { get; set; }
        public int? DailyPayment { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual AllowancePercentage AllowancePercentage { get; set; }
        public virtual Country Country { get; set; }
        public virtual CountryGroup CountryGroup { get; set; }
        public virtual CurrencyName CurrencyName { get; set; }
        public virtual Rank FromRank { get; set; }
        public virtual Rank ToRank { get; set; }
        public virtual ICollection<Allowance> Allowances { get; set; }
    }
}
