using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaInstructorType
    {
        public BnaInstructorType()
        {
            BnaExamInstructorAssigns = new HashSet<BnaExamInstructorAssign>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int BnaInstructorTypeId { get; set; }
        public string InstructorTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaExamInstructorAssign> BnaExamInstructorAssigns { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
