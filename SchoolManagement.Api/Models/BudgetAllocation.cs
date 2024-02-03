using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BudgetAllocation
    {
        public int BudgetAllocationId { get; set; }
        public int? BudgetCodeId { get; set; }
        public int? BudgetTypeId { get; set; }
        public int? FiscalYearId { get; set; }
        public string BudgetCodeName { get; set; }
        public string Percentage { get; set; }
        public double? Amount { get; set; }
        public string Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BudgetCode BudgetCode { get; set; }
        public virtual BudgetType BudgetType { get; set; }
        public virtual FiscalYear FiscalYear { get; set; }
    }
}
