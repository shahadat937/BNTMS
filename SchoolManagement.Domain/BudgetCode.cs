using SchoolManagement.Domain;
using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BudgetCode:BaseDomainEntity
    {
        public BudgetCode()
        {
            BudgetAllocations = new HashSet<BudgetAllocation>();
            CourseBudgetAllocations = new HashSet<CourseBudgetAllocation>();
        }

        public int BudgetCodeId { get; set; } 
        public string? BudgetCodes { get; set; }
        public string? Name { get; set; }
        public double? TotalBudget { get; set; }
        public double? AvailableAmount { get; set; }
        public double? TargetAmount { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BudgetAllocation> BudgetAllocations { get; set; }
        public virtual ICollection<CourseBudgetAllocation> CourseBudgetAllocations { get; set; }
    }
}
