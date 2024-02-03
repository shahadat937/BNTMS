using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaClassTestType : BaseDomainEntity
    {
        public BnaClassTestType()
        {
            BnaClassTests = new HashSet<BnaClassTest>();
        }

        public int BnaClassTestTypeId { get; set; }
        public string? Name { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaClassTest> BnaClassTests { get; set; }
    }
}
