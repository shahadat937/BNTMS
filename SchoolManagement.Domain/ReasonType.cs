using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ReasonType : BaseDomainEntity
    {
        public ReasonType()
        {
            JoiningReasons = new HashSet<JoiningReason>();
        }

        public int ReasonTypeId { get; set; }
        public string ReasonTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<JoiningReason> JoiningReasons { get; set; }
    }
}
