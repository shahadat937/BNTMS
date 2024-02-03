using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaClassSectionSelection
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
        public string SectionName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaClassSchedule> BnaClassSchedules { get; set; }
        public virtual ICollection<BnaExamRoutineLog> BnaExamRoutineLogs { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<TraineeSectionSelection> TraineeSectionSelectionBnaClassSectionSelections { get; set; }
        public virtual ICollection<TraineeSectionSelection> TraineeSectionSelectionPreviewsSections { get; set; }
    }
}
