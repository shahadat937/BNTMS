using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Commands
{
    public class DeleteBnaClassScheduleStatusCommand : IRequest
    {
        public int BnaClassScheduleStatusId { get; set; } 
    }
} 
 