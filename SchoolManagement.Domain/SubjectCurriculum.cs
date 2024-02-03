using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class SubjectCurriculum : BaseDomainEntity
    {
        public int SubjectCurriculumId { get; set; }
        public string? CurriculumName { get; set; }
        public int? Status { get; set; }
        public bool? IsActive { get; set; }
    }
}
