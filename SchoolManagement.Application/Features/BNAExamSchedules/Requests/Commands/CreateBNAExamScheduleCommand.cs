using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.BnaExamSchedule;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Requests.Commands
{
    public class CreateBnaExamScheduleCommand : IRequest<BaseCommandResponse>
    {
        public CreateBnaExamScheduleDto BnaExamScheduleDto { get; set; }

    }
}
 