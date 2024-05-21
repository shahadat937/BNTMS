using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseLevel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseLevels.Requests.Queries
{
    public class GetCourseLevelDetailRequest : IRequest<CourseLevelDto>
    {
        public int CourseLevelId { get; set; }
    }
}
