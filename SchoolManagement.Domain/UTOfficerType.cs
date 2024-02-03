using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class UtofficerType : BaseDomainEntity
    {
        public UtofficerType()
        {
            
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int UtofficerTypeId { get; set; }
        public string UtofficerTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
