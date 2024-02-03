using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SaylorSubBranch : BaseDomainEntity
    {
        public SaylorSubBranch()
        {
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            SubjectMarks = new HashSet<SubjectMark>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int SaylorSubBranchId { get; set; }
        public int? SaylorBranchId { get; set; }
        public string? Name { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public virtual SaylorBranch? SaylorBranch { get; set; }
        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
