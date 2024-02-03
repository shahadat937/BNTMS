using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class QuestionType : BaseDomainEntity
    {
        public QuestionType()
        {
            Questions = new HashSet<Question>();
        }

        public int QuestionTypeId { get; set; }
        public string Question { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

    }
}
