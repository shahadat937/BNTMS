using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CovidVaccine
    {
        public int CovidVaccineId { get; set; }
        public int? TraineeId { get; set; }
        public DateTime? Date { get; set; }
        public string VaccineName { get; set; }
        public string Place { get; set; }
        public string NoOfDose { get; set; }
        public string Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
