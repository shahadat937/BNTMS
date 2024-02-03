using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public  class SubjectCategory : BaseDomainEntity
    {
        public SubjectCategory()
        {
            BnaClassTests = new HashSet<BnaClassTest>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();
        }

        public int SubjectCategoryId { get; set; }
        public string SubjectCategoryName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaClassTest> BnaClassTests { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
    }
}
