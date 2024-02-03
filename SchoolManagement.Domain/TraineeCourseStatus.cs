using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TraineeCourseStatus : BaseDomainEntity
    {
        public TraineeCourseStatus()
        {
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int TraineeCourseStatusId { get; set; }
        public string? TraineeCourseStatusName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
