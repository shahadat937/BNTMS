using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ExamAttemptType
    {
        public ExamAttemptType()
        {
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int ExamAttemptTypeId { get; set; }
        public string ExamAttemptTypeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
