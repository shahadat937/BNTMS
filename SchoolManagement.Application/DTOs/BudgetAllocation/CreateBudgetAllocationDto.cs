using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetAllocation
{
    public class CreateBudgetAllocationDto : IBudgetAllocationDto
    {
        public int BudgetAllocationId { get; set; }
        public int? BudgetCodeId { get; set; }
        public int? BudgetTypeId { get; set; }
        public int? FiscalYearId { get; set; }
        public string? BudgetCodeName { get; set; }
        public string? Percentage { get; set; }
        public double? Amount { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
