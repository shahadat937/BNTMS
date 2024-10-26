﻿using MediatR;
using SchoolManagement.Application.DTOs.BudgetTransaction;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTransactionType.Request.Queries
{
    public class GetBudgetTransactionListRequest:IRequest<List<BudgetTransactionDto>>
    {
        public QueryParams? QueryParams { get; set; }
        public int BudgetCodeId { get; set; }
        public int BudgetTypeId { get; set; }
    }
}
