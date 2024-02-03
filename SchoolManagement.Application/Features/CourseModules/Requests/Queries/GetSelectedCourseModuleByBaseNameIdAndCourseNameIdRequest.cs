using MediatR;
using SchoolManagement.Application.DTOs.CourseModule;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseModules.Requests.Queries
{
    public class GetSelectedCourseModuleByBaseNameIdAndCourseNameIdRequest : IRequest<List<SelectedModel>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
    }
}

