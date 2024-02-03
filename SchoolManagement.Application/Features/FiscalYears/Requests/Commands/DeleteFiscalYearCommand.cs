using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FiscalYears.Requests.Commands
{
    public class DeleteFiscalYearCommand : IRequest
    {
        public int FiscalYearId { get; set; }
    }
} 
