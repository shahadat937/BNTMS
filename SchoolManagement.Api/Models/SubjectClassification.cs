using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class SubjectClassification
    {
        public SubjectClassification()
        {
            BnaSubjectNames = new HashSet<BnaSubjectName>();
        }

        public int SubjectClassificationId { get; set; }
        public string SubjectClassificationName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
    }
}
