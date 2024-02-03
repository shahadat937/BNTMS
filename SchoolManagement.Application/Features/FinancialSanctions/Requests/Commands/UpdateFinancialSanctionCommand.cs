using MediatR;
using SchoolManagement.Application.DTOs.FinancialSanction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FinancialSanctions.Requests.Commands
{
    public class UpdateFinancialSanctionCommand : IRequest<Unit>
    {
        public FinancialSanctionDto FinancialSanctionDto { get; set; }
    }
}
