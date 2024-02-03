using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Rank: BaseDomainEntity
    {
        public Rank()
        {
            BnaSemesterDurations = new HashSet<BnaSemesterDuration>();
            ParentRelatives = new HashSet<ParentRelative>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            AllowanceCategoryFromRanks = new HashSet<AllowanceCategory>();
            AllowanceCategoryToRanks = new HashSet<AllowanceCategory>();
            AllowanceFromRanks = new HashSet<Allowance>();
            AllowanceToRanks = new HashSet<Allowance>();
            TraineeNominations = new HashSet<TraineeNomination>();

        }

        public int RankId { get; set; }
        public string RankName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public int CompleteStatus { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaSemesterDuration> BnaSemesterDurations { get; set; }
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<AllowanceCategory> AllowanceCategoryFromRanks { get; set; }
        public virtual ICollection<AllowanceCategory> AllowanceCategoryToRanks { get; set; }
        public virtual ICollection<Allowance> AllowanceFromRanks { get; set; }
        public virtual ICollection<Allowance> AllowanceToRanks { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }

    }
}
