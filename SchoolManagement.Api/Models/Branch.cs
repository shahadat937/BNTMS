using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Branch
    {
        public Branch()
        {
            BnaExamMarks = new HashSet<BnaExamMark>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();
            ClassRoutines = new HashSet<ClassRoutine>();
            SubjectMarks = new HashSet<SubjectMark>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int BranchId { get; set; }
        public int? TraineeStatusId { get; set; }
        public string BranchName { get; set; }
        public string ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual TraineeStatus TraineeStatus { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
