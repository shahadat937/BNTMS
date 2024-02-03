using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class InstallmentPaidDetail : BaseDomainEntity
    {
        public int InstallmentPaidDetailId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeId { get; set; }
        public double? TotalUsd { get; set; }
        public double? TotalBdt { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public int? PaymentCompletedStatus { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
    }
}
