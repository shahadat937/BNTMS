using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Complexion: BaseDomainEntity
    {
        public Complexion()
        {
            
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
        }

        public int ComplexionId { get; set; }
        public string ComplexionName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

       
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }

    }
}
