using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Board : BaseDomainEntity
    {
        public Board()
        {
            EducationalQualifications = new HashSet<EducationalQualification>();
        }

        public int BoardId { get; set; }
        public string BoardName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EducationalQualification> EducationalQualifications { get; set; }
    }
}
