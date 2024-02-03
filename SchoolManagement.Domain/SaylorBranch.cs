using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SaylorBranch : BaseDomainEntity
    {
        public SaylorBranch()
        {
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            SaylorSubBranches = new HashSet<SaylorSubBranch>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();
            SubjectMarks = new HashSet<SubjectMark>();
            TraineeNominations = new HashSet<TraineeNomination>();

        }

        public int SaylorBranchId { get; set; }
        public string? Name { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<SaylorSubBranch> SaylorSubBranches { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
