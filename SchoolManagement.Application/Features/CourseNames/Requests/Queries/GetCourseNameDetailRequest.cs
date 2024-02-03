using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseName;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseNames.Requests.Queries
{
    public class GetCourseNameDetailRequest : IRequest<CourseNameDto>
    {
        public int CourseNameId { get; set; }
    }
}
