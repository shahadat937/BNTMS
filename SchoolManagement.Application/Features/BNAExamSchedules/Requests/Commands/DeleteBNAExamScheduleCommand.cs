using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Requests.Commands
{
    public class DeleteBnaExamScheduleCommand : IRequest
    {
        public int BnaExamScheduleId { get; set; }
    }
}
  
  