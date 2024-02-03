using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Assessment : BaseDomainEntity
    {
        public Assessment()
        {
            CourseGradingEntries = new HashSet<CourseGradingEntry>();
        }

        public int AssessmentId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<CourseGradingEntry> CourseGradingEntries { get; set; }
    }
}
