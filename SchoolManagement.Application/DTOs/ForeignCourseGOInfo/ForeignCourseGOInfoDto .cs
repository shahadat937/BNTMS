using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseGOInfo
{
    public class ForeignCourseGOInfoDto : IForeignCourseGOInfoDto
    {
        public int ForeignCourseGOInfoId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public string? DocumentName { get; set; }
        public string? FileUpload { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? CourseDuration { get; set; }
        public string? DurationFrom { get; set; }
        public string? DurationTo { get; set; }
        public string? CourseName { get; set; }

    }
}
