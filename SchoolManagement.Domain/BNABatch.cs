using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaBatch : BaseDomainEntity
    {

        public BnaBatch()
        {
            Attendances = new HashSet<Attendance>();
            BnaClassSchedules = new HashSet<BnaClassSchedule>();
            BnaCurriculumUpdates = new HashSet<BnaCurriculumUpdate>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
            BnaExamMarks = new HashSet<BnaExamMark>();
            BnaExamRoutineLogs = new HashSet<BnaExamRoutineLog>();
            BnaExamSchedules = new HashSet<BnaExamSchedule>();
            BnaPromotionLogs = new HashSet<BnaPromotionLog>();
            BnaSemesterDurations = new HashSet<BnaSemesterDuration>();
            TraineeBioDataGeneralInfos = new HashSet<TraineeBioDataGeneralInfo>();
            TraineePictures = new HashSet<TraineePicture>();
            TraineeSectionSelections = new HashSet<TraineeSectionSelection>();
        }

        public int BnaBatchId { get; set; }
        public string BatchName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public int CompleteStatus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BnaClassSchedule> BnaClassSchedules { get; set; }
        public virtual ICollection<BnaCurriculumUpdate> BnaCurriculumUpdates { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<BnaExamRoutineLog> BnaExamRoutineLogs { get; set; }
        public virtual ICollection<BnaExamSchedule> BnaExamSchedules { get; set; }
        public virtual ICollection<BnaPromotionLog> BnaPromotionLogs { get; set; }
        public virtual ICollection<BnaSemesterDuration> BnaSemesterDurations { get; set; }
        public virtual ICollection<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfos { get; set; }
        public virtual ICollection<TraineePicture> TraineePictures { get; set; }
        public virtual ICollection<TraineeSectionSelection> TraineeSectionSelections { get; set; }
    }
}
