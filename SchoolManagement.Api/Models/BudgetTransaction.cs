using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public class BudgetTransaction
    {
        public int BudgetTransactionId { get; set; }
        public int BudgetCodeId { get; set; }
        public int BudgetTypeId { get; set; }
        public int FiscalYearId { get; set; }
        public double? Amount { get; set; }
        public int AdminAuthority { get; set; }
        public int DeskAuthority { get; set; }
        public string CourseName { get; set; }
        public int MenuPosition { get; set; }
        public int? Status { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public virtual BudgetCode BudgetCode { get; set; }
        public virtual BudgetType BudgetType { get; set; }
        public virtual FiscalYear FiscalYear { get; set; }
    }
}
