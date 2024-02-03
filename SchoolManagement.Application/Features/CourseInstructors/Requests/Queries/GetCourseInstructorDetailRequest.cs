using MediatR;
using SchoolManagement.Application.DTOs.CourseInstructors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetCourseInstructorDetailRequest : IRequest<CourseInstructorDto>
    {
        public int CourseInstructorId { get; set; }
    }
}
 