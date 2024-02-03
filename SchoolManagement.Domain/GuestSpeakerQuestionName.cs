using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class GuestSpeakerQuestionName : BaseDomainEntity
    {
        public GuestSpeakerQuestionName()
        {
            GuestSpeakerQuationGroups = new HashSet<GuestSpeakerQuationGroup>();
        }

        public int GuestSpeakerQuestionNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<GuestSpeakerQuationGroup> GuestSpeakerQuationGroups { get; set; }
    }
}
