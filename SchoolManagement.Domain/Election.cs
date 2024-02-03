using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Election : BaseDomainEntity
    {
        public int ElectionId { get; set; }
        public int TraineeId { get; set; }
        public int ElectedId { get; set; }
        public string? InstituteName { get; set; }
        public string? AppointmentName { get; set; }
        public DateTime? DurationFrom { get; set; }
        public DateTime? DurationTo { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Elected Elected { get; set; } = null!;
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;

    }
}
