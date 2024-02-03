using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CourseGradingEntry
    {
        public int CourseGradingEntryId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? AssessmentId { get; set; }
        public double? MarkObtained { get; set; }
        public string Grade { get; set; }
        public string MarkFrom { get; set; }
        public string MarkTo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Assessment Assessment { get; set; }
        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual CourseName CourseName { get; set; }
    }
}
