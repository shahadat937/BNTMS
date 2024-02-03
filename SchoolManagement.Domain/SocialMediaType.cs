using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SocialMediaType:BaseDomainEntity
    {
        public SocialMediaType()
        {
            SocialMedia = new HashSet<SocialMedia>();
        }

        public int SocialMediaTypeId { get; set; }
        public string SocialMediaTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<SocialMedia> SocialMedia { get; set; }
    }
}
