using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BudgetCode
    {
        public BudgetCode()
        {
            BudgetAllocations = new HashSet<BudgetAllocation>();
            CourseBudgetAllocations = new HashSet<CourseBudgetAllocation>();
        }

        public int BudgetCodeId { get; set; }
        public string BudgetCodes { get; set; }
        public string Name { get; set; }
        public double? TotalBudget { get; set; }
        public double? AvailableAmount { get; set; }
        public double? TargetAmount { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BudgetAllocation> BudgetAllocations { get; set; }
        public virtual ICollection<CourseBudgetAllocation> CourseBudgetAllocations { get; set; }
    }
}
