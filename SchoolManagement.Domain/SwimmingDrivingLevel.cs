using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SwimmingDrivingLevel : BaseDomainEntity
    {
        public int SwimmingDrivingLevelId { get; set; }
        public int SwimmingDrivingId { get; set; }
        public int LevelTypeId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public virtual CodeValue LevelType { get; set; } = null!;
        public virtual SwimmingDriving SwimmingDriving { get; set; } = null!;

    }
}
