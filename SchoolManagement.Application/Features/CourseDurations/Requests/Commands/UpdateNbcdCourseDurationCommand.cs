using MediatR;
using SchoolManagement.Application.DTOs.CourseDurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Commands
{
    public class UpdateNbcdCourseDurationCommand : IRequest<Unit>
    {
        public UpdateNbcdCourseDurationDto CourseDurationDto { get; set; } 
    }
}
