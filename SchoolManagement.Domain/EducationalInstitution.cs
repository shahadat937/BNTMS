using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class EducationalInstitution : BaseDomainEntity 
    {
        public int EducationalInstitutionId { get; set; }
        public int TraineeId { get; set; }
        public int DistrictId { get; set; }
        public int ThanaId { get; set; }
        public string InstituteName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ClassStudiedFrom { get; set; } = null!;
        public string ClassStudiedTo { get; set; } = null!;
        public DateTime YearFrom { get; set; }
        public DateTime YearTo { get; set; }
        public string? AdditionaInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual District District { get; set; } = null!;
        public virtual Thana Thana { get; set; } = null!;
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;
    }
}
