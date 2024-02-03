using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class KindOfSubject : BaseDomainEntity
    {
        public KindOfSubject()
        {
            BnaSubjectNames = new HashSet<BnaSubjectName>();
        }

        public int KindOfSubjectId { get; set; }
        public string? KindOfSubjectName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
    }
}
