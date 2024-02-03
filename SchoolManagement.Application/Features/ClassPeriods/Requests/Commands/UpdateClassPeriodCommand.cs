using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Commands
{
    public class UpdateClassPeriodCommand : IRequest<Unit>
    {
        public ClassPeriodDto ClassPeriodDto { get; set; }
    }
} 
