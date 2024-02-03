using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TraineeVisitedAboard : BaseDomainEntity
    {
        public int TraineeVisitedAboardId { get; set; }
        public int TraineeId { get; set; }
        public int CountryId { get; set; }
        public string PurposeOfVisit { get; set; } = null!;
        public DateTime DurationFrom { get; set; }
        public DateTime DurationTo { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;
    }
}
