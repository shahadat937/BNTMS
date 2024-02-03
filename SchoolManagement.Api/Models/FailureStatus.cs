using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class FailureStatus
    {
        public FailureStatus()
        {
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int FailureStatusId { get; set; }
        public string FailureStatusName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
