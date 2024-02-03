using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ExamMarkRemark
    {
        public ExamMarkRemark()
        {
            BnaExamMarks = new HashSet<BnaExamMark>();
        }

        public int ExamMarkRemarksId { get; set; }
        public string MarkRemark { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
    }
}
