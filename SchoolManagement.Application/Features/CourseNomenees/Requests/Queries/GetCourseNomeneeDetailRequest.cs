using MediatR;
using SchoolManagement.Application.DTOs.CourseNomenees;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseNomenees.Requests.Queries
{
    public class GetCourseNomeneeDetailRequest : IRequest<CourseNomeneeDto>
    {
        public int CourseNomeneeId { get; set; }
    }
}
 