﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManagement.Application.DTOs.BudgetTransaction
{
    public class CreateBudgetTransactionDto:IBudgetTransactionDto
    {
        public int BudgetTransactionId { get; set; }
        public int? BudgetTypeId { get; set; }
        public int BudgetCodeId { get; set; }
        public int? Amount { get; set; }
        public int? AdminAuthority { get; set; }
        public int? DeskAuthority { get; set; }
        public int? CourseName { get; set; }
        public int? MenuPosition { get; set; }
        int IBudgetTransactionDto.BudgetTypeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int? IBudgetTransactionDto.BudgetCodeId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
