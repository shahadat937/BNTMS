using MediatR;
using SchoolManagement.Application.DTOs.Allowance;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Allowances.Requests.Commands
{
    public class UpdateAllowanceCommand : IRequest<Unit>
    {
        public AllowanceDto AllowanceDto { get; set; }
    }
}
 