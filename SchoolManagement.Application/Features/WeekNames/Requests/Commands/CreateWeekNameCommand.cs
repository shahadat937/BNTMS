using MediatR;
using SchoolManagement.Application.DTOs.WeekName;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.WeekNames.Requests.Commands
{
    public class CreateWeekNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateWeekNameDto WeekNameDto { get; set; }
    }
}
