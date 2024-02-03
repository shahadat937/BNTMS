using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaSemester : BaseDomainEntity
    {
        public BnaSemester()
        {
            Attendances = new HashSet<Attendance>();
            BnaClassSchedules = new HashSet<BnaClassSchedule>();
            BnaClassTests = new HashSet<BnaClassTest>();
            BnaCurriculumUpdates = new HashSet<BnaCurriculumUpdate>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
            BnaExamMarks = new HashSet<BnaExamMark>();
            BnaExamRoutineLogs = new HashSet<BnaExamRoutineLog>();
            BnaExamSchedules = new HashSet<BnaExamSchedule>();
            BnaPromotionLogs = new HashSet<BnaPromotionLog>();
            BnaSemesterDurationBnaSemesters = new HashSet<BnaSemesterDuration>();
            BnaSemesterDurationNextSemesters = new HashSet<BnaSemesterDuration>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            TraineePictures = new HashSet<TraineePicture>();
            TraineeSectionSelections = new HashSet<TraineeSectionSelection>();
            SubjectMarks = new HashSet<SubjectMark>();
            CourseInstructors = new HashSet<CourseInstructor>();
            CourseNomenees = new HashSet<CourseNomenee>();

        }

        public int BnaSemesterId { get; set; }
        public string SemesterName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BnaClassSchedule> BnaClassSchedules { get; set; }
        public virtual ICollection<BnaClassTest> BnaClassTests { get; set; }
        public virtual ICollection<BnaCurriculumUpdate> BnaCurriculumUpdates { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<BnaExamRoutineLog> BnaExamRoutineLogs { get; set; }
        public virtual ICollection<BnaExamSchedule> BnaExamSchedules { get; set; }
        public virtual ICollection<BnaPromotionLog> BnaPromotionLogs { get; set; }
        public virtual ICollection<BnaSemesterDuration> BnaSemesterDurationBnaSemesters { get; set; }
        public virtual ICollection<BnaSemesterDuration> BnaSemesterDurationNextSemesters { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<TraineePicture> TraineePictures { get; set; }
        public virtual ICollection<TraineeSectionSelection> TraineeSectionSelections { get; set; }
        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }

        public virtual ICollection<CourseNomenee> CourseNomenees { get; set; }

    }
}
