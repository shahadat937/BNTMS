using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class FailureStatus : BaseDomainEntity
    {
        public FailureStatus()
        {
            
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int FailureStatusId { get; set; }
        public string FailureStatusName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
