using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class PresentBillet : BaseDomainEntity
    {
        public PresentBillet()
        {
            
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int PresentBilletId { get; set; }
        public string PresentBilletName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }

    }
}
