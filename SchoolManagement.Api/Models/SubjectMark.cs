using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class SubjectMark
    {
        public SubjectMark()
        {
            BnaExamMarks = new HashSet<BnaExamMark>();
        }

        public int SubjectMarkId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BranchId { get; set; }
        public int? SaylorSubBranchId { get; set; }
        public int? SaylorBranchId { get; set; }
        public int? CourseModuleId { get; set; }
        public int? MarkTypeId { get; set; }
        public double? PassMark { get; set; }
        public double? Mark { get; set; }
        public string Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual BnaSubjectName BnaSubjectName { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual CourseModule CourseModule { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual MarkType MarkType { get; set; }
        public virtual SaylorBranch SaylorBranch { get; set; }
        public virtual SaylorSubBranch SaylorSubBranch { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
    }
}
