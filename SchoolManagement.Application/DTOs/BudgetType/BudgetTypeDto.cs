using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetType
{
    public class BudgetTypeDto : IBudgetTypeDto
    {
        public int BudgetTypeId { get; set; }
        public string? BudgetTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
