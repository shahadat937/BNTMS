using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SocialMedia : BaseDomainEntity
    {

        public int SocialMediaId { get; set; }
        public int TraineeId { get; set; }
        public int SocialMediaTypeId { get; set; }
        public string? SocialMediaAccountName { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual SocialMediaType SocialMediaType { get; set; } = null!;
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;
    }
}
