using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetType
{
    public interface IBudgetTypeDto
    {
        public int BudgetTypeId { get; set; }
        public string? BudgetTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
