using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class MarkType
    {
        public MarkType()
        {
            SubjectMarks = new HashSet<SubjectMark>();
        }

        public int MarkTypeId { get; set; }
        public string TypeName { get; set; }
        public string ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int? PolicyStatus { get; set; }

        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
    }
}
