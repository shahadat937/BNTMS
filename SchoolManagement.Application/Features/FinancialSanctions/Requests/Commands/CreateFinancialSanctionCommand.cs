using MediatR;
using SchoolManagement.Application.DTOs.FinancialSanction;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FinancialSanctions.Requests.Commands
{
    public class CreateFinancialSanctionCommand : IRequest<BaseCommandResponse>
    {
        public CreateFinancialSanctionDto FinancialSanctionDto { get; set; }
    }
}
