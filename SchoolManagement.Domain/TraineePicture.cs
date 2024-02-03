using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TraineePicture : BaseDomainEntity
    {
        public int TraineePictureId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? TraineeId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public string? ImageLink { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BnaBatch? BnaBatch { get; set; }
        public virtual BnaSemester? BnaSemester { get; set; }
        public virtual BnaSemesterDuration? BnaSemesterDuration { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }




    }
}
