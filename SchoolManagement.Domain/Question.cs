using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Question : BaseDomainEntity
    {

        public int QuestionId { get; set; }
        public int? TraineeId { get; set; }
        public int? QuestionTypeId { get; set; }
        public string? Answer { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual QuestionType? QuestionType { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
    }
}
