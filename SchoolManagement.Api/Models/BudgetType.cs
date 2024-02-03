using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BudgetType
    {
        public BudgetType()
        {
            BudgetAllocations = new HashSet<BudgetAllocation>();
        }

        public int BudgetTypeId { get; set; }
        public string BudgetTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BudgetAllocation> BudgetAllocations { get; set; }
    }
}
