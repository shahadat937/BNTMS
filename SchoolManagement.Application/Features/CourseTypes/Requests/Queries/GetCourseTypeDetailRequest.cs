using MediatR;
using SchoolManagement.Application.DTOs.CourseTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTypes.Requests.Queries
{
    public class GetCourseTypeDetailRequest : IRequest<CourseTypeDto>
    {
        public int CourseTypeId { get; set; }
    }
}
