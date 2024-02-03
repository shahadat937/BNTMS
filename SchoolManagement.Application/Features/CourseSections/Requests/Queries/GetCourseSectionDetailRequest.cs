using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseSection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseSections.Requests.Queries
{
    public class GetCourseSectionDetailRequest : IRequest<CourseSectionDto>
    {
        public int CourseSectionId { get; set; }
    }
}
