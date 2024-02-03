using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.CourseName
{
    public class CreateCourseNameDto : ICourseNameDto
    {
        public int CourseNameId { get; set; }
        public int? CourseTypeId { get; set; }
        public string Course { get; set; } = null!;
        public string? ShortName { get; set; }
        public string? CourseSyllabus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public IFormFile? Doc { get; set; }
    }
}
