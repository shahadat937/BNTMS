using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ForeignCourseOthersDocument
    {
        public int ForeignCourseOthersDocumentId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? TraineeId { get; set; }
        public int? ForeignCourseDocTypeId { get; set; }
        public int? Status { get; set; }
        public string FileUpload { get; set; }
        public string Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseDuration CourseDuration { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual ForeignCourseDocType ForeignCourseDocType { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
