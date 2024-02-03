using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ExamCenter : BaseDomainEntity
    {
        public ExamCenter()
        {

            ExamCenterSelections = new HashSet<ExamCenterSelection>();
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int ExamCenterId { get; set; }
        public string? ExamCenterName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ExamCenterSelection> ExamCenterSelections { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }

    }
}
