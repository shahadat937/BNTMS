using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ClassInstructorAssign
    {
        public int ClassInstructorAssignId { get; set; }
        public int? BnaClassScheduleId { get; set; }
        public int? TraineeId { get; set; }
        public int? DurationForm { get; set; }
        public int? DurationTo { get; set; }
        public int? Date { get; set; }
        public int? ClassLocation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual BnaClassSchedule BnaClassSchedule { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
