using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class BnaClassScheduleStatus : BaseDomainEntity
    {
        public BnaClassScheduleStatus()
        {
            BnaClassSchedules = new HashSet<BnaClassSchedule>();
            ClassPeriods = new HashSet<ClassPeriod>();
        }

        public int BnaClassScheduleStatusId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaClassSchedule> BnaClassSchedules { get; set; }
        public virtual ICollection<ClassPeriod> ClassPeriods { get; set; }
    }
}
