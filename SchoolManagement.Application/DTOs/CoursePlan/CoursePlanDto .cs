using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CoursePlan
{
    public class CoursePlanDto : ICoursePlanDto
    {
        //public int CoursePlanCreateId { get; set; }
        //public int? CourseDurationId { get; set; }
        //public int? CourseNameId { get; set; }
        //public int? BaseSchoolNameId { get; set; }
        public string? CoursePlanName { get; set; }
        public string? Value { get; set; }
        //public int? Status { get; set; }
        //public int? MenuPosition { get; set; }
        //public bool IsActive { get; set; }
        public string? CourseDuration { get; set; }
        public string? CourseName { get; set; }
        public string? BaseSchoolName { get; set; }
    }
}
