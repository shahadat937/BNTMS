using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FinancialSanctions.Requests.Commands
{
    public class DeleteFinancialSanctionCommand : IRequest
    {
        public int FinancialSanctionId { get; set; }
    }
}
