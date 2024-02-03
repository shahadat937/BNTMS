using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ExamMarkRemarks : BaseDomainEntity
    {
        public ExamMarkRemarks()
        {
            BnaExamMarks = new HashSet<BnaExamMark>();
        }
        public int ExamMarkRemarksId { get; set; }
        public string? MarkRemark { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
    }
}
