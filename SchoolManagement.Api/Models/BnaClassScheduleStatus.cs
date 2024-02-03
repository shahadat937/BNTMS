using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaClassScheduleStatus
    {
        public BnaClassScheduleStatus()
        {
            BnaClassSchedules = new HashSet<BnaClassSchedule>();
            ClassPeriods = new HashSet<ClassPeriod>();
        }

        public int BnaClassScheduleStatusId { get; set; }
        public string Name { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaClassSchedule> BnaClassSchedules { get; set; }
        public virtual ICollection<ClassPeriod> ClassPeriods { get; set; }
    }
}
