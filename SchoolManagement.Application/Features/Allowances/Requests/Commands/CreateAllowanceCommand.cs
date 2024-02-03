using MediatR;
using SchoolManagement.Application.DTOs.Allowance;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Allowances.Requests.Commands
{
    public class CreateAllowanceCommand : IRequest<BaseCommandResponse>
    {
        public CreateAllowanceDto AllowanceDto { get; set; }
    }
}
 