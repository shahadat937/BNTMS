using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.EducationalInstitutions
{
    public interface IEducationalInstitutionDto 
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
        public string? AdditionaInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 