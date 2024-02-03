using SchoolManagement.Domain;
using SchoolManagement.Domain.Common; 

namespace SchoolManagement.Domain
{
    public class CovidVaccine:BaseDomainEntity
    {
        public int CovidVaccineId { get; set; }
        public int? TraineeId { get; set; }
        public DateTime? Date { get; set; }
        public string? VaccineName { get; set; }
        public string? Place { get; set; }
        public string? NoOfDose { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
