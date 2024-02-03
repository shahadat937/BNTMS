using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.CourseSection
{
    public class CourseSectionDto : ICourseSectionDto
    {

        public int CourseSectionId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public string? SectionName { get; set; }
        public string? SectionShortName { get; set; }
        public int? BnaCurriculumTypeId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public string? BaseSchoolName { get; set; }
        public string? CourseName { get; set; }

        public string? BnaCurriculumType { get; set; }

    }
}
