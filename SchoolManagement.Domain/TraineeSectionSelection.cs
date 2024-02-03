using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TraineeSectionSelection : BaseDomainEntity
    {
        public int TraineeSectionSelectionId { get; set; }
        public int TraineeId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? BnaClassSectionSelectionId { get; set; }
        public int? PreviewsSectionId { get; set; }
        public int? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BnaBatch? BnaBatch { get; set; }
        public virtual BnaClassSectionSelection? BnaClassSectionSelection { get; set; }
        public virtual BnaSemester? BnaSemester { get; set; }
        public virtual BnaClassSectionSelection? PreviewsSection { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;




    }
}
