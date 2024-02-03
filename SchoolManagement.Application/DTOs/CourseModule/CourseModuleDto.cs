using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.CourseModule
{
    public class CourseModuleDto : ICourseModuleDto
    {
        public int CourseModuleId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public string? ModuleName { get; set; }
        public string? NameOfModule { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public string? BaseSchoolName { get; set; }
        public string? CourseName { get; set; }

    }
}
