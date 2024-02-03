using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class TraineeCourseStatus
    {
        public TraineeCourseStatus()
        {
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int TraineeCourseStatusId { get; set; }
        public string TraineeCourseStatusName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
