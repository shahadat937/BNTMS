using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class TdecQuestionName
    {
        public TdecQuestionName()
        {
            TdecQuationGroups = new HashSet<TdecQuationGroup>();
        }

        public int TdecQuestionNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TdecQuationGroup> TdecQuationGroups { get; set; }
    }
}
