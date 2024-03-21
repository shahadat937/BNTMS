using MediatR;
using SchoolManagement.Application.DTOs.BnaClassPeriod;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassPeriods.Requests.Commands
{
    public class CreateBnaClassPeriodCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaClassPeriodDto BnaClassPeriodDto { get; set; }
    }
}
