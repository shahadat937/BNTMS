using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class RecordOfService : BaseDomainEntity
    {

        public int RecordOfServiceId { get; set; }
        public int? TraineeId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string? ShipEstablishment { get; set; }
        public string? Appointment { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
    }
}
