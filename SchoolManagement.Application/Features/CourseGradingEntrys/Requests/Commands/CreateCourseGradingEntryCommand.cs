using MediatR;
using SchoolManagement.Application.DTOs.CourseGradingEntry;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Commands
{
    public class CreateCourseGradingEntryCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseGradingEntryDto CourseGradingEntryDto { get; set; }
    }
}
