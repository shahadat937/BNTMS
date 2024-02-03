using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaPromotionStatus
    {
        public BnaPromotionStatus()
        {
            BnaPromotionLogs = new HashSet<BnaPromotionLog>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int BnaPromotionStatusId { get; set; }
        public string PromotionStatusName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaPromotionLog> BnaPromotionLogs { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
