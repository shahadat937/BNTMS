using MediatR;
using SchoolManagement.Application.DTOs.CoursePlan;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CoursePlans.Requests.Commands
{
    public class CreateCoursePlanCommand : IRequest<BaseCommandResponse>
    {
        public CreateCoursePlanDto CoursePlanDto { get; set; }
    }
}
