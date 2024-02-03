using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Group : BaseDomainEntity
    {
        public Group()
        {
            EducationalQualifications = new HashSet<EducationalQualification>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EducationalQualification> EducationalQualifications { get; set; }
    }
}
