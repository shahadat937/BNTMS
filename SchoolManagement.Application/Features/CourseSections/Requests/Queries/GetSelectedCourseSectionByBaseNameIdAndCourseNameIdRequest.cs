using MediatR;
using SchoolManagement.Application.DTOs.CourseSection;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseSections.Requests.Queries
{
    public class GetSelectedCourseSectionByBaseNameIdAndCourseNameIdRequest : IRequest<List<SelectedModel>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
    }
}

