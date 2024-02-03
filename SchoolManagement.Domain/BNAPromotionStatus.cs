using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaPromotionStatus : BaseDomainEntity
    {
        public BnaPromotionStatus()
        {
            BnaPromotionLogs = new HashSet<BnaPromotionLog>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int BnaPromotionStatusId { get; set; }
        public string PromotionStatusName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaPromotionLog> BnaPromotionLogs { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
