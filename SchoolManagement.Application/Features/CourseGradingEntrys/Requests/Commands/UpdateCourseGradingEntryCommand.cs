using MediatR;
using SchoolManagement.Application.DTOs.CourseGradingEntry;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Commands
{
    public class UpdateCourseGradingEntryCommand : IRequest<Unit>
    {
        public CourseGradingEntryDto CourseGradingEntryDto { get; set; }
    }
}
