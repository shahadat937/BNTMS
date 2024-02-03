using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CourseType
    {
        public CourseType()
        {
            BnaSubjectNames = new HashSet<BnaSubjectName>();
            CourseBudgetAllocations = new HashSet<CourseBudgetAllocation>();
            CourseDurations = new HashSet<CourseDuration>();
            CourseNames = new HashSet<CourseName>();
            Documents = new HashSet<Document>();
            InterServiceMarks = new HashSet<InterServiceMark>();
        }

        public int CourseTypeId { get; set; }
        public string CourseTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<CourseBudgetAllocation> CourseBudgetAllocations { get; set; }
        public virtual ICollection<CourseDuration> CourseDurations { get; set; }
        public virtual ICollection<CourseName> CourseNames { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<InterServiceMark> InterServiceMarks { get; set; }
    }
}
