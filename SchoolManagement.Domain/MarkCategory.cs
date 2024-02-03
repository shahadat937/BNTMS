using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class MarkCategory : BaseDomainEntity
    {
        public MarkCategory()
        {
            SubjectMarks = new HashSet<SubjectMark>();
        }

        public int MarkCategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; } 
        public bool IsActive { get; set; }

        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
    }
}
