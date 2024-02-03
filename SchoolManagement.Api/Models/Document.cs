using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? InterServiceCourseDocTypeId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentUpload { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseDuration CourseDuration { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual InterServiceCourseDocType InterServiceCourseDocType { get; set; }
    }
}
