using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            CourseBudgetAllocations = new HashSet<CourseBudgetAllocation>();
        }

        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CourseBudgetAllocation> CourseBudgetAllocations { get; set; }
    }
}
