using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TdecQuestionName : BaseDomainEntity
    {
        public TdecQuestionName()
        {
            TdecQuationGroups = new HashSet<TdecQuationGroup>();
            
        }
        public int TdecQuestionNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? Name { get; set; } 
        public bool Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TdecQuationGroup> TdecQuationGroups { get; set; }
       
    }
}
