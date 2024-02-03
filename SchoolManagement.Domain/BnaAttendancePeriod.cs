using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaAttendancePeriod : BaseDomainEntity
    {
        public int BnaAttendancePeriodId { get; set; }
        public string? PeriodName { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
