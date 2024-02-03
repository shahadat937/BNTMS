using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ResultStatus : BaseDomainEntity
    {
        public ResultStatus()
        {
            BnaSubjectNames = new HashSet<BnaSubjectName>();
        }

        public int ResultStatusId { get; set; }
        public string? ResultStatusName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }

    }
}
