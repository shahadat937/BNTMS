using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TraineeLanguage: BaseDomainEntity 
    {
        public int TraineeLanguageId { get; set; }
        public int TraineeId { get; set; }
        public int LanguageId { get; set; }

        public string? Speaking { get; set; }
        public string? Writing { get; set; }
        public string? Reading { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Language Language { get; set; } = null!;
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;
    }
}
