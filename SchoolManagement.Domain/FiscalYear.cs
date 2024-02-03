using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class FiscalYear : BaseDomainEntity
    {
        public FiscalYear()
        {
            CourseDurations = new HashSet<CourseDuration>();
            BudgetAllocations = new HashSet<BudgetAllocation>();
        }

        public int FiscalYearId { get; set; }
        public string? FiscalYearName { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<BudgetAllocation> BudgetAllocations { get; set; }
        public virtual ICollection<CourseDuration> CourseDurations { get; set; }

    }
}
