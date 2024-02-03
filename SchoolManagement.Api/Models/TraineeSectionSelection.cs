using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class TraineeSectionSelection
    {
        public int TraineeSectionSelectionId { get; set; }
        public int TraineeId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? BnaClassSectionSelectionId { get; set; }
        public int? PreviewsSectionId { get; set; }
        public int? IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BnaClassSectionSelection BnaClassSectionSelection { get; set; }
        public virtual BnaSemester BnaSemester { get; set; }
        public virtual BnaClassSectionSelection PreviewsSection { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
