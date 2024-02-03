using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseOthersDocument
{
    public interface IForeignCourseOthersDocumentDto
    {
        public int ForeignCourseOthersDocumentId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? TraineeId { get; set; }
        public int? ForeignCourseDocTypeId { get; set; }
        public int? Status { get; set; }
        public string? FileUpload { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
