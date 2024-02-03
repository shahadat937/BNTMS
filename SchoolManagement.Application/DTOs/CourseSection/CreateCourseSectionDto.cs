using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CourseSection;

namespace SchoolManagement.Application.DTOs.CourseSection
{
    public class CreateCourseSectionDto : ICourseSectionDto
    {
        public int CourseSectionId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public string? SectionName { get; set; }
        public string? SectionShortName { get; set; }
        public int? BnaCurriculumTypeId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
