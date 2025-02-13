﻿using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetRunningCourseDurationListBySchoolFromSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public int CourseTypeId { get; set; }
        public int BaseSchoolNameId { get; set; }
        public DateTime? CurrentDate { get; set; }
        public int ViewStatus { get; set; }
        public string SearchTerm { get; set; }
    }
}
