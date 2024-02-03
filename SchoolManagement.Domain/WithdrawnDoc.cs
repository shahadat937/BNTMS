using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class WithdrawnDoc : BaseDomainEntity
    {
        public WithdrawnDoc()
        {
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int WithdrawnDocId { get; set; }
        public string? WithdrawnDocName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
