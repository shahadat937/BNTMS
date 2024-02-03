using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Rank
    {
        public Rank()
        {
            AllowanceCategoryFromRanks = new HashSet<AllowanceCategory>();
            AllowanceCategoryToRanks = new HashSet<AllowanceCategory>();
            AllowanceFromRanks = new HashSet<Allowance>();
            AllowanceToRanks = new HashSet<Allowance>();
            BnaSemesterDurations = new HashSet<BnaSemesterDuration>();
            ParentRelatives = new HashSet<ParentRelative>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int RankId { get; set; }
        public string RankName { get; set; }
        public string Position { get; set; }
        public int? MenuPosition { get; set; }
        public int CompleteStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AllowanceCategory> AllowanceCategoryFromRanks { get; set; }
        public virtual ICollection<AllowanceCategory> AllowanceCategoryToRanks { get; set; }
        public virtual ICollection<Allowance> AllowanceFromRanks { get; set; }
        public virtual ICollection<Allowance> AllowanceToRanks { get; set; }
        public virtual ICollection<BnaSemesterDuration> BnaSemesterDurations { get; set; }
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
