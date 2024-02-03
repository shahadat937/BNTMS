using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class FinancialSanction : BaseDomainEntity
    {
        public FinancialSanction()
        {
            ForeignCourseOtherDocs = new HashSet<ForeignCourseOtherDoc>();
            

        }

        public int FinancialSanctionId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ForeignCourseOtherDoc> ForeignCourseOtherDocs { get; set; }
       
    }
}
