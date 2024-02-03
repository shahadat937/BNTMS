using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.RoutineSoftCopyUpload
{
    public class RoutineSoftCopyUploadDto : IRoutineSoftCopyUploadDto
    {
        public int RoutineSoftCopyUploadId { get; set; }
        public int CourseDurationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? DocumentLink { get; set; }
        public string? DocumentName { get; set; }
        public int? Status { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsActive { get; set; } 
        public string? CourseDuration { get; set; }
        public string? CourseName { get; set; }

    }
}
