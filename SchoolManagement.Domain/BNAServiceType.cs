using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaServiceType : BaseDomainEntity
    {
        public BnaServiceType()
        {
            
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int BnaServiceTypeId { get; set; }
        public string ServiceName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

       
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
