﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetTransaction
{
    public interface IBudgetTransactionDto
    {
        public int BudgetTransactionId { get; set; }
        public int BudgetCodeId { get; set; }
        public int BudgetTypeId { get; set; }
        public int? FiscalYearId { get; set; }
        public double? Amount { get; set; }
        public int? AdminAuthority { get; set; }
        public int? DeskAuthority { get; set; }
        public int? CourseName { get; set; }
        public int? MenuPosition { get; set; }
        public int? Status { get; set; }
        public bool IsActive { get; set; }

    }
}
