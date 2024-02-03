using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ExamCenter
    {
        public ExamCenter()
        {
            ExamCenterSelections = new HashSet<ExamCenterSelection>();
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int ExamCenterId { get; set; }
        public string ExamCenterName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ExamCenterSelection> ExamCenterSelections { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
