using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaServiceType
    {
        public BnaServiceType()
        {
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int BnaServiceTypeId { get; set; }
        public string ServiceName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
