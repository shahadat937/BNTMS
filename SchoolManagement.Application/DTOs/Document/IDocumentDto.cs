using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Document
{
    public interface IDocumentDto
    {
        public int DocumentId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? InterServiceCourseDocTypeId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentUpload { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
