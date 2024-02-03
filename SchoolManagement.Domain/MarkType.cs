using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class MarkType : BaseDomainEntity
    {
        public MarkType()
        {
            SubjectMarks = new HashSet<SubjectMark>();
        }

        public int MarkTypeId { get; set; }
        public string? TypeName { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; } 
        public bool IsActive { get; set; }
        public int? PolicyStatus { get; set; }

        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
    }
}
