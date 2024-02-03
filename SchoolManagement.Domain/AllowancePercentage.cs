using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class AllowancePercentage : BaseDomainEntity
    {
        public AllowancePercentage()
        {
           
            AllowanceCategories = new HashSet<AllowanceCategory>();
        }

        public int AllowancePercentageId { get; set; }
        public string? AllowanceName { get; set; }
        public string? Percentage { get; set; }
        public int? DisplayPriority { get; set; }
        public bool IsActive { get; set; }

        
        public virtual ICollection<AllowanceCategory> AllowanceCategories { get; set; }

    }
}
