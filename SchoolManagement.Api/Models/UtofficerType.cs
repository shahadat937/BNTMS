using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class UtofficerType
    {
        public UtofficerType()
        {
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int UtofficerTypeId { get; set; }
        public string UtofficerTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
