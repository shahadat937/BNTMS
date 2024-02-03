using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class EducationalInstitution
    {
        public int EducationalInstitutionId { get; set; }
        public int TraineeId { get; set; }
        public int DistrictId { get; set; }
        public int ThanaId { get; set; }
        public string InstituteName { get; set; }
        public string Address { get; set; }
        public string ClassStudiedFrom { get; set; }
        public string ClassStudiedTo { get; set; }
        public DateTime YearFrom { get; set; }
        public DateTime YearTo { get; set; }
        public string AdditionaInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual District District { get; set; }
        public virtual Thana Thana { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
