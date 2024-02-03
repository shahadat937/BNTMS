using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class ExamType : BaseDomainEntity
    {
        public ExamType()
        {
            Attendances = new HashSet<Attendance>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
            BnaExamSchedules = new HashSet<BnaExamSchedule>();
            EducationalQualifications = new HashSet<EducationalQualification>();
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int ExamTypeId { get; set; }
        public string ExamTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamSchedule> BnaExamSchedules { get; set; }
        public virtual ICollection<EducationalQualification> EducationalQualifications { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
