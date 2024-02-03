using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaSemesterDuration : BaseDomainEntity
    {
        public BnaSemesterDuration()
        {
            Attendances = new HashSet<Attendance>();
            BnaClassSchedules = new HashSet<BnaClassSchedule>();
            BnaClassTests = new HashSet<BnaClassTest>();
            BnaCurriculumUpdates = new HashSet<BnaCurriculumUpdate>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
            BnaExamSchedules = new HashSet<BnaExamSchedule>();
            TraineePictures = new HashSet<TraineePicture>();
            TraineeNominations = new HashSet<TraineeNomination>();
            CourseWeeks = new HashSet<CourseWeek>();
        }

        public int BnaSemesterDurationId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? NextSemesterId { get; set; }
        public int? RankId { get; set; }
        public int? SemesterLocationType { get; set; }
        public bool? IsSemesterComplete { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public string? Location { get; set; }

        public virtual BnaBatch? BnaBatch { get; set; } 
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual BnaSemester? BnaSemester { get; set; }
        public virtual BnaSemester? NextSemester { get; set; }
        public virtual Rank? Rank { get; set; }
        public virtual CodeValue? SemesterLocationTypeNavigation { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BnaClassSchedule> BnaClassSchedules { get; set; }
        public virtual ICollection<BnaClassTest> BnaClassTests { get; set; }
        public virtual ICollection<BnaCurriculumUpdate> BnaCurriculumUpdates { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamSchedule> BnaExamSchedules { get; set; }
        public virtual ICollection<TraineePicture> TraineePictures { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
        public virtual ICollection<CourseWeek> CourseWeeks { get; set; }
    }
}
