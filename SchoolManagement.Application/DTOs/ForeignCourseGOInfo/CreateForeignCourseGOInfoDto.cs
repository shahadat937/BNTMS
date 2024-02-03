using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseGOInfo
{
    public class CreateForeignCourseGOInfoDto : IForeignCourseGOInfoDto
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

        public IFormFile? Doc { get; set; }
    }
}
