using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaCurriculumUpdate : BaseDomainEntity
    {
        public int BnaCurriculumUpdateId { get; set; }
        public int BnaBatchId { get; set; }
        public int BnaSemesterId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? BnaCurriculumTypeId { get; set; }
        public int? TraineeId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual BnaBatch BnaBatch { get; set; } = null!;
        public virtual BnaCurriculumType? BnaCurriculumType { get; set; }
        public virtual BnaSemester BnaSemester { get; set; } = null!;
        public virtual BnaSemesterDuration? BnaSemesterDuration { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
    }
}
