using MediatR;
using SchoolManagement.Application.DTOs.CoursePlan;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoursePlans.Requests.Commands
{
    public class UpdateCoursePlanCommand : IRequest<Unit>
    {
        public CoursePlanDto CoursePlanDto { get; set; }
    }
}
 