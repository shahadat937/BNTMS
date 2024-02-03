using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class UtofficerCategory : BaseDomainEntity
    {
        public UtofficerCategory()
        {
            
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int UtofficerCategoryId { get; set; }
        public string UtofficerCategoryName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

       
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
    }
}
