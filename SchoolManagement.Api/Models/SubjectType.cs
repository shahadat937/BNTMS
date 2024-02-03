using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class SubjectType
    {
        public SubjectType()
        {
            BnaSubjectNames = new HashSet<BnaSubjectName>();
        }

        public int SubjectTypeId { get; set; }
        public string SubjectTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
    }
}
