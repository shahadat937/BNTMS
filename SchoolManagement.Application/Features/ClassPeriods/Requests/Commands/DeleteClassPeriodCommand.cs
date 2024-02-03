using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Commands
{
    public class DeleteClassPeriodCommand : IRequest
    {
        public int ClassPeriodId { get; set; }
    } 
}
