using MediatR;
using SchoolManagement.Application.DTOs.WeekName;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.WeekNames.Requests.Commands
{
    public class UpdateWeekNameCommand : IRequest<Unit>
    {
        public WeekNameDto WeekNameDto { get; set; }
    }
}
