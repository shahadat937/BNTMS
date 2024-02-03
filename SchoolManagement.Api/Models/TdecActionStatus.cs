using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class TdecActionStatus
    {
        public TdecActionStatus()
        {
            TdecGroupResults = new HashSet<TdecGroupResult>();
        }

        public int TdecActionStatusId { get; set; }
        public string Name { get; set; }
        public double? Mark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TdecGroupResult> TdecGroupResults { get; set; }
    }
}
