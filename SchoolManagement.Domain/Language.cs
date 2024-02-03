using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Language : BaseDomainEntity
    {
        public Language()
        {
            TraineeLanguages = new HashSet<TraineeLanguage>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeLanguage> TraineeLanguages { get; set; }
    }
} 
