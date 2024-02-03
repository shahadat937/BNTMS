using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SubjectType : BaseDomainEntity
    {
        public SubjectType()
        {
            BnaSubjectNames = new HashSet<BnaSubjectName>();
        }

        public int SubjectTypeId { get; set; }
        public string? SubjectTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
    }
}
