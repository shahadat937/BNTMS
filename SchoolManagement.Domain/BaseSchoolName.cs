using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BaseSchoolName : BaseDomainEntity
    {
        public BaseSchoolName()
        {
            Attendances = new HashSet<Attendance>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
            BnaExamInstructorAssigns = new HashSet<BnaExamInstructorAssign>();
            BnaExamMarks = new HashSet<BnaExamMark>();
            BnaSubjectNames = new HashSet<BnaSubjectName>();
            Bulletins = new HashSet<Bulletin>();
            ClassPeriods = new HashSet<ClassPeriod>();
            ClassRoutines = new HashSet<ClassRoutine>();
            CourseDurations = new HashSet<CourseDuration>();
            //CourseDurationNbcdSchools = new HashSet<CourseDuration>();
            CourseGradingEntries = new HashSet<CourseGradingEntry>();
            CourseInstructors = new HashSet<CourseInstructor>();
            CourseNomenees = new HashSet<CourseNomenee>();
            CourseModules = new HashSet<CourseModule>();
            CoursePlanCreates = new HashSet<CoursePlanCreate>();
            CourseSections = new HashSet<CourseSection>();
            CourseTasks = new HashSet<CourseTask>();
            CourseWeeks = new HashSet<CourseWeek>();
            Events = new HashSet<Event>();
            IndividualBulletins = new HashSet<IndividualBulletin>();
            IndividualNotices = new HashSet<IndividualNotice>();
            NewEntryEvaluations = new HashSet<NewEntryEvaluation>();
            Notices = new HashSet<Notice>();
            ReadingMaterials = new HashSet<ReadingMaterial>();
            RoutineNotes = new HashSet<RoutineNote>();
            SubjectMarks = new HashSet<SubjectMark>();
            TraineeAssessmentCreates = new HashSet<TraineeAssessmentCreate>();
            TdecQuationGroups = new HashSet<TdecQuationGroup>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            TrainingObjectives = new HashSet<TrainingObjective>();
            TrainingSyllabus = new HashSet<TrainingSyllabus>();
            TraineeAssignmentSubmits = new HashSet<TraineeAssignmentSubmit>();
            Notifications = new HashSet<Notification>();
            RoutineSoftCopyUploads = new HashSet<RoutineSoftCopyUpload>();
            GuestSpeakerQuationGroups = new HashSet<GuestSpeakerQuationGroup>();
            //Instructors = new HashSet<Instructor>();
            // GuestSpeakerQuestionNames = new HashSet<GuestSpeakerQuestionName>();
        }

        public int BaseSchoolNameId { get; set; }
        public int? BaseNameId { get; set; }
        public string? SchoolName { get; set; }
        public string? ShortName { get; set; }
        public string? SchoolLogo { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public string? ContactPerson { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? Cellphone { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public int? BranchLevel { get; set; }
        public int? FirstLevel { get; set; }
        public int? SecondLevel { get; set; }
        public int? ThirdLevel { get; set; }
        public int? FourthLevel { get; set; }
        public int? FifthLevel { get; set; }
        public string? ServerName { get; set; }
        public string? SchoolHistory { get; set; }

        public virtual BaseName? BaseName { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamInstructorAssign> BnaExamInstructorAssigns { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<Bulletin> Bulletins { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<ClassPeriod> ClassPeriods { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<CourseDuration> CourseDurations { get; set; }
        //public virtual ICollection<CourseDuration> CourseDurationNbcdSchools { get; set; }
        public virtual ICollection<CourseGradingEntry> CourseGradingEntries { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<CourseNomenee> CourseNomenees { get; set; }

        public virtual ICollection<CourseModule> CourseModules { get; set; }
        public virtual ICollection<CoursePlanCreate> CoursePlanCreates { get; set; }
        public virtual ICollection<CourseSection> CourseSections { get; set; }
        public virtual ICollection<CourseTask> CourseTasks { get; set; }
        public virtual ICollection<CourseWeek> CourseWeeks { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<IndividualBulletin> IndividualBulletins { get; set; }
        public virtual ICollection<IndividualNotice> IndividualNotices { get; set; }
        public virtual ICollection<NewEntryEvaluation> NewEntryEvaluations { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<ReadingMaterial> ReadingMaterials { get; set; }
        public virtual ICollection<RoutineNote> RoutineNotes { get; set; }
        public virtual ICollection<RoutineSoftCopyUpload> RoutineSoftCopyUploads { get; set; }
        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<TraineeAssessmentCreate> TraineeAssessmentCreates { get; set; }
        public virtual ICollection<TdecQuationGroup> TdecQuationGroups { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<TrainingObjective> TrainingObjectives { get; set; }
        public virtual ICollection<TrainingSyllabus> TrainingSyllabus { get; set; }
        public virtual ICollection<TraineeAssignmentSubmit> TraineeAssignmentSubmits { get; set; }
        public virtual ICollection<GuestSpeakerQuationGroup> GuestSpeakerQuationGroups { get; set; }
        //public virtual ICollection<Instructor> Instructors { get; set; }
      //  public virtual ICollection<GuestSpeakerQuestionName> GuestSpeakerQuestionNames { get; set; }
    }
}
