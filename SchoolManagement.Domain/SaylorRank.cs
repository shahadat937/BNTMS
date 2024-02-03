using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SaylorRank : BaseDomainEntity
    {
        public SaylorRank()
        {
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeNominations = new HashSet<TraineeNomination>();

        }

        public int SaylorRankId { get; set; }
        public string? Name { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
