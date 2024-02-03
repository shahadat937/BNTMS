using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetCode
{
    public interface IBudgetCodeDto
    {
        public int BudgetCodeId { get; set; }
        public string? BudgetCodes { get; set; }
        public string? Name { get; set; }
        public double? TotalBudget { get; set; }
        public double? AvailableAmount { get; set; }
        public double? TargetAmount { get; set; }
        public bool IsActive { get; set; }
    }
}
