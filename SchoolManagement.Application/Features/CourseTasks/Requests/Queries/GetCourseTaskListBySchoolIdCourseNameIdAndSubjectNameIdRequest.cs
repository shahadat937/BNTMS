using MediatR;
using SchoolManagement.Application.DTOs.CourseTask;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTasks.Requests.Queries
{
    public class GetCourseTaskListBySchoolIdCourseNameIdAndSubjectNameIdRequest : IRequest<List<CourseTaskDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int BnaSubjectNameId { get; set; }

    }
}

