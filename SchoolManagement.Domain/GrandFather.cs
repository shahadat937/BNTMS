using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class GrandFather : BaseDomainEntity
    {
        public int GrandFatherId { get; set; }
        public int TraineeId { get; set; }
        public int GrandFatherTypeId { get; set; }
        public int OccupationId { get; set; }
        public int NationalityId { get; set; }
        public string? GrandFathersName { get; set; }
        public int? Age { get; set; }
        public int DeadStatus { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CodeValue DeadStatusNavigation { get; set; } = null!;
        public virtual GrandFatherType GrandFatherType { get; set; } = null!;
        public virtual Nationality Nationality { get; set; } = null!;
        public virtual Occupation Occupation { get; set; } = null!;
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;

    }
}
