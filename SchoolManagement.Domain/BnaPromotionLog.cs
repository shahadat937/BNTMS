using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaPromotionLog : BaseDomainEntity
    {
        public int BnaPromotionLogId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? TraineeId { get; set; }
        public int? BnaPromotionStatusId { get; set; }
        public DateTime? PromotionDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }

        public virtual BnaBatch? BnaBatch { get; set; }
        public virtual BnaPromotionStatus? BnaPromotionStatus { get; set; }
        public virtual BnaSemester? BnaSemester { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
    }
}
