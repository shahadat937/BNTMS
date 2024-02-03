using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.CourseModule
{
    public class CreateCourseModuleDto : ICourseModuleDto
    {
        public int CourseModuleId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public string? ModuleName { get; set; }
        public string? NameOfModule { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
