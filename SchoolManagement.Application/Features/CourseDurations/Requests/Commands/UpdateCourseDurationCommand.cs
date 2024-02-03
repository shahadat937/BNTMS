using MediatR;
using SchoolManagement.Application.DTOs.CourseDurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class UpdateCourseDurationCommand : IRequest<Unit>
    {
        public CourseDurationDto CourseDurationDto { get; set; } 
    }
}
