using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class GrandFather
    {
        public int GrandFatherId { get; set; }
        public int? TraineeId { get; set; }
        public int? GrandFatherTypeId { get; set; }
        public int? OccupationId { get; set; }
        public int? NationalityId { get; set; }
        public string GrandFathersName { get; set; }
        public int? Age { get; set; }
        public int? DeadStatus { get; set; }
        public string AdditionalInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual CodeValue DeadStatusNavigation { get; set; }
        public virtual GrandFatherType GrandFatherType { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
