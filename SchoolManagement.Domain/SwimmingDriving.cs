using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SwimmingDriving : BaseDomainEntity
    {
        public SwimmingDriving()
        {
            SwimmingDrivingLevels = new HashSet<SwimmingDrivingLevel>();
        }

        public int SwimmingDrivingId { get; set; }
        public int TraineeId { get; set; }
        public string AdditionalInformation { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;
        public virtual ICollection<SwimmingDrivingLevel> SwimmingDrivingLevels { get; set; }
    }
}
