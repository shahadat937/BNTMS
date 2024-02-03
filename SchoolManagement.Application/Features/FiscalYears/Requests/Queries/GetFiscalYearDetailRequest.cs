using MediatR;
using SchoolManagement.Application.DTOs.FiscalYears;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FiscalYears.Requests.Queries
{
    public class GetFiscalYearDetailRequest : IRequest<FiscalYearDto>
    {
        public int FiscalYearId { get; set; }
    }
}
