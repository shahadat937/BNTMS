using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ExamCenterSelection : BaseDomainEntity
    {
        public int ExamCenterSelectionId { get; set; }
        public int TraineeNominationId { get; set; }
        public int BnaExamScheduleId { get; set; }
        public int ExamCenterId { get; set; }
        public int TraineeId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual TraineeNomination? TraineeNomination { get; set; }
        public virtual BnaExamSchedule? BnaExamSchedule { get; set; }
        public virtual ExamCenter? ExamCenter { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }



    }
}
