using MediatR;
using SchoolManagement.Application.DTOs.FinancialSanction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FinancialSanctions.Requests.Queries
{
    public class GetFinancialSanctionDetailRequest : IRequest<FinancialSanctionDto>
    {
        public int FinancialSanctionId { get; set; }
    }
}
