using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.BudgetTransaction
{
    public interface IBudgetTransactionDto
    {
        public int BudgetTransaction { get; set; }
        public int? BudgetCodeId { get; set; }
        public int? BudgetTypeId { get; set; }
        public int? FiscalYearId { get; set; }
        public int? AdminAuthorityId { get; set; }
        public int? DeskId { get; set; }
        public string? CourseNameId { get; set; }
        public double? Amount { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? BudgetCode { get; set; }
        public string? BudgetType { get; set; }
        public string? FiscalYear { get; set; }
        public string? CourseName { get; set; }
        public string? AdminAuthority { get; set; }
        public string? Desk { get; set; }
    }
}
