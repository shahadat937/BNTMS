using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Branch : BaseDomainEntity 
    {
        public Branch()
        {
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();
            ClassRoutines = new HashSet<ClassRoutine>();
            SubjectMarks = new HashSet<SubjectMark>();
            BnaExamMarks = new HashSet<BnaExamMark>();
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; } = null!;
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
