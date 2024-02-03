using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class FamilyNomination
    {
        public int FamilyNominationId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeId { get; set; }
        public int? FamilyInfoId { get; set; }
        public int? FundingDetailId { get; set; }
        public int? RelationTypeId { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseDuration CourseDuration { get; set; }
        public virtual FamilyInfo FamilyInfo { get; set; }
        public virtual CodeValue FundingDetail { get; set; }
        public virtual RelationType RelationType { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
        public virtual TraineeNomination TraineeNomination { get; set; }
    }
}
