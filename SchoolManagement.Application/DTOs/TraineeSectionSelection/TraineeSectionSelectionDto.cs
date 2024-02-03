using System;

namespace SchoolManagement.Application.DTOs.TraineeSectionSelection
{
    public class TraineeSectionSelectionDto : ITraineeSectionSelectionDto
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


        public string? BnaBatch { get; set; }
        public string? BnaClassSectionSelection { get; set; }
        public string? BnaSemester { get; set; }
        public string? PreviewsSection { get; set; }
        public string? Trainee { get; set; }

    }
}
