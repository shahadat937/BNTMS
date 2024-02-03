using MediatR;
using SchoolManagement.Application.DTOs.BnaClassScheduleStatuses;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Commands
{
    public class CreateBnaClassScheduleStatusCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaClassScheduleStatusDto BnaClassScheduleStatusDto { get; set; }
    }
}
