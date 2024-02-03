using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaClassSectionSelection : BaseDomainEntity
    {
        public BnaClassSectionSelection()
        {
            BnaClassSchedules = new HashSet<BnaClassSchedule>();
            BnaExamRoutineLogs = new HashSet<BnaExamRoutineLog>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            TraineeSectionSelectionBnaClassSectionSelections = new HashSet<TraineeSectionSelection>();
            TraineeSectionSelectionPreviewsSections = new HashSet<TraineeSectionSelection>();
        }

        public int BnaClassSectionSelectionId { get; set; }
        public string SectionName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaClassSchedule> BnaClassSchedules { get; set; }
        public virtual ICollection<BnaExamRoutineLog> BnaExamRoutineLogs { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<TraineeSectionSelection> TraineeSectionSelectionBnaClassSectionSelections { get; set; }
        public virtual ICollection<TraineeSectionSelection> TraineeSectionSelectionPreviewsSections { get; set; }
    }
}
