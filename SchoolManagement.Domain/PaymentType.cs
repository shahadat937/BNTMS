using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class PaymentType : BaseDomainEntity
    {
        public PaymentType()
        {
            CourseBudgetAllocations = new HashSet<CourseBudgetAllocation>();
        }

        public int PaymentTypeId { get; set; }
        public string? PaymentTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CourseBudgetAllocation> CourseBudgetAllocations { get; set; }
    }
}
