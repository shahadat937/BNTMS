using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Queries
{
    public class GetClassPeriodDetailRequest : IRequest<ClassPeriodDto>
    {
        public int ClassPeriodId { get; set; }
    }
}
 