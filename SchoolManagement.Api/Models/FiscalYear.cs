using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class FiscalYear
    {
        public FiscalYear()
        {
            BudgetAllocations = new HashSet<BudgetAllocation>();
            CourseDurations = new HashSet<CourseDuration>();
        }

        public int FiscalYearId { get; set; }
        public string FiscalYearName { get; set; }
        public string ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BudgetAllocation> BudgetAllocations { get; set; }
        public virtual ICollection<CourseDuration> CourseDurations { get; set; }
    }
}
