using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SubjectClassification : BaseDomainEntity
    {
        public SubjectClassification()
        {
            BnaSubjectNames = new HashSet<BnaSubjectName>();
        }

        public int SubjectClassificationId { get; set; }
        public string SubjectClassificationName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
    }
}
