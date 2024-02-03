using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ExamAttemptType : BaseDomainEntity
    {
        public ExamAttemptType()
        {

            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int ExamAttemptTypeId { get; set; }
        public string? ExamAttemptTypeName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }

    }
}
