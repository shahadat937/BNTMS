using MediatR;
using SchoolManagement.Application.DTOs.CourseGradingEntry;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Queries
{
    public class GetCourseGradingEntryDetailRequest : IRequest<CourseGradingEntryDto>
    {
        public int CourseGradingEntryId { get; set; }
    }
}
