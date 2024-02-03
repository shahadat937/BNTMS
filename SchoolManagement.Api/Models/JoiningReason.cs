using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class JoiningReason
    {
        public int JoiningReasonId { get; set; }
        public int TraineeId { get; set; }
        public int ReasonTypeId { get; set; }
        public string IfAnotherReason { get; set; }
        public string AdditionlInformation { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ReasonType ReasonType { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
