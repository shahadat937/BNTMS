using SchoolManagement.Domain;
using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{ 
    public class BudgetType: BaseDomainEntity
    {
        public BudgetType()
        {
            BudgetAllocations = new HashSet<BudgetAllocation>();
        }

        public int BudgetTypeId { get; set; }
        public string? BudgetTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BudgetAllocation> BudgetAllocations { get; set; }
    }
}
