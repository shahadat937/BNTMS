using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.ReadingMaterial
{
    public class ReadingMaterialDto : IReadingMaterialDto
    {
        public int ReadingMaterialId { get; set; }
        public int ReadingMaterialTitleId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? ShowRightId { get; set; }
        public int? DownloadRightId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentLink { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? ApprovedUser { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public string? ReadingMaterialTitle { get; set; } 
        public string? CourseName { get; set; }
        public string? BaseSchoolName { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentIcon { get; set; }
        public string? ShowRight { get; set; }
        public string? DownloadRight { get; set; }
        public string? AurhorName { get; set; }
        public string? PublisherName { get; set; }

    }
}
