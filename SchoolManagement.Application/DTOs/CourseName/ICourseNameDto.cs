using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseName
{
    public interface ICourseNameDto
    {
        public int CourseNameId { get; set; }
        public int? CourseTypeId { get; set; }
        public string Course { get; set; } 
        public string? ShortName { get; set; }
        public string? CourseSyllabus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
