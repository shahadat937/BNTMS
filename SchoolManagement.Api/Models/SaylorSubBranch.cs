using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class SaylorSubBranch
    {
        public SaylorSubBranch()
        {
            BnaSubjectNames = new HashSet<BnaSubjectName>();
            SubjectMarks = new HashSet<SubjectMark>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int SaylorSubBranchId { get; set; }
        public int? SaylorBranchId { get; set; }
        public string Name { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual SaylorBranch SaylorBranch { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
