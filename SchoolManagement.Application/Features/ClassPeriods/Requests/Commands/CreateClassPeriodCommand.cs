using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Commands
{
    public class CreateClassPeriodCommand : IRequest<BaseCommandResponse>
    {
        public CreateClassPeriodDto? ClassPeriodDto { get; set; }
    }
} 
