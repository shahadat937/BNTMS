using MediatR;
using SchoolManagement.Application.DTOs.CourseGradingEntry;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Queries
{
    public class GetCourseGradingEntryListBySchoolNameIdAndCourseNameIdRequest : IRequest<List<CourseGradingEntryDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
    }
}

