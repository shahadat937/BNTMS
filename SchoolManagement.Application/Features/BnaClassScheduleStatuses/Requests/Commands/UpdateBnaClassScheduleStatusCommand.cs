using MediatR;
using SchoolManagement.Application.DTOs.BnaClassScheduleStatuses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Commands
{
    public class UpdateBnaClassScheduleStatusCommand : IRequest<Unit>
    {
        public BnaClassScheduleStatusDto BnaClassScheduleStatusDto { get; set; }
    } 
}
  