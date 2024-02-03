using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class NewAtempt : BaseDomainEntity
    {
        public NewAtempt()
        {

            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int NewAtemptId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }

    }
}
