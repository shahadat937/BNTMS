﻿using MediatR;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetUpcomingCourseDurationListByNbcdSchoolFromSpRequest : IRequest<object>
    {
        //public QueryParams QueryParams { get; set; }
        public int CourseTypeId { get; set; }
        public int BaseSchoolNameId { get; set; }
        public DateTime? CurrentDate { get; set; }
    }
}
 