using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ExamPeriodType:BaseDomainEntity
    {
        public int ExamPeriodTypeId { get; set; }
        public string? ExamPeriodName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
