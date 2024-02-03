using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ReasonType
    {
        public ReasonType()
        {
            JoiningReasons = new HashSet<JoiningReason>();
        }

        public int ReasonTypeId { get; set; }
        public string ReasonTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<JoiningReason> JoiningReasons { get; set; }
    }
}
