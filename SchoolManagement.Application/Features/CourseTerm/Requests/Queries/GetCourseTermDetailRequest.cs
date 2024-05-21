using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseTerm;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTerms.Requests.Queries
{
    public class GetCourseTermDetailRequest : IRequest<CourseTermDto>
    {
        public int CourseTermId { get; set; }
    }
}
