using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CourseSection
{
    public interface ICourseSectionDto
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
