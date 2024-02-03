using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class SubjectCategory
    {
        public SubjectCategory()
        {
            BnaClassTests = new HashSet<BnaClassTest>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();
        }

        public int SubjectCategoryId { get; set; }
        public string SubjectCategoryName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaClassTest> BnaClassTests { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
    }
}
