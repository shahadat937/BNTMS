using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseTypes
{
    public class CourseTypeDto : ICourseTypeDto
    {
        public int CourseTypeId { get; set; }
        public string CourseTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
