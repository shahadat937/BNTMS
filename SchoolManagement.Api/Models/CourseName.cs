using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CourseName : BaseDomainEntity
    {
        public CourseName()
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
            CourseInstructors = new HashSet<CourseInstructor>();
            CourseModules = new HashSet<CourseModule>();
            CoursePlanCreates = new HashSet<CoursePlanCreate>();
            CourseBudgetAllocations = new HashSet<CourseBudgetAllocation>();
            CourseSections = new HashSet<CourseSection>();
            CourseWeeks = new HashSet<CourseWeek>();
            Events = new HashSet<Event>();
            ReadingMaterials = new HashSet<ReadingMaterial>();
            SubjectMarks = new HashSet<SubjectMark>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            TraineeNominations = new HashSet<TraineeNomination>();
            Allowances = new HashSet<Allowance>();
            Documents = new HashSet<Document>();
            InterServiceMarks = new HashSet<InterServiceMark>();
            CourseGradingEntries = new HashSet<CourseGradingEntry>();
            NewEntryEvaluations = new HashSet<NewEntryEvaluation>();
            Notices = new HashSet<Notice>();
            IndividualBulletins = new HashSet<IndividualBulletin>();
            IndividualNotices = new HashSet<IndividualNotice>();
            TdecQuationGroups = new HashSet<TdecQuationGroup>();
            CourseTasks = new HashSet<CourseTask>();
            TrainingObjectives = new HashSet<TrainingObjective>();
            TrainingSyllabi = new HashSet<TrainingSyllabus>();
            RoutineNotes = new HashSet<RoutineNote>();
            InstructorAssignments = new HashSet<InstructorAssignment>();
            TraineeAssignmentSubmits = new HashSet<TraineeAssignmentSubmit>();
            ForeignCourseOtherDocs = new HashSet<ForeignCourseOtherDoc>();
            ForeignCourseGOInfos = new HashSet<ForeignCourseGOInfo>();
            ForeignCourseOthersDocuments = new HashSet<ForeignCourseOthersDocument>();
            InterServiceCourseReports = new HashSet<InterServiceCourseReport>();
            GuestSpeakerQuationGroups = new HashSet<GuestSpeakerQuationGroup>();
            ForeignTrainingCourseReports = new HashSet<ForeignTrainingCourseReport>();
            //  GuestSpeakerQuestionNames = new HashSet<GuestSpeakerQuestionName>();
            CourseNomenees = new HashSet<CourseNomenee>();

        }

        public int CourseNameId { get; set; }
        public int? CourseTypeId { get; set; }
        public string Course { get; set; } = null!;
        public string? ShortName { get; set; }
        public string? CourseSyllabus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseType? CourseType { get; set; }
        public virtual ICollection<InterServiceCourseReport> InterServiceCourseReports { get; set; }
        public virtual ICollection<ForeignCourseGOInfo> ForeignCourseGOInfos { get; set; }
        public virtual ICollection<ForeignCourseOtherDoc> ForeignCourseOtherDocs { get; set; }
        public virtual ICollection<TrainingSyllabus> TrainingSyllabi { get; set; }
        public virtual ICollection<TrainingObjective> TrainingObjectives { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<ForeignTrainingCourseReport> ForeignTrainingCourseReports { get; set; }
        public virtual ICollection<BnaExamInstructorAssign> BnaExamInstructorAssigns { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<Bulletin> Bulletins { get; set; }
        public virtual ICollection<ClassPeriod> ClassPeriods { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<CourseDuration> CourseDurations { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<CourseModule> CourseModules { get; set; }
        public virtual ICollection<CoursePlanCreate> CoursePlanCreates { get; set; }
        public virtual ICollection<CourseWeek> CourseWeeks { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<ReadingMaterial> ReadingMaterials { get; set; }
        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
        public virtual ICollection<Allowance> Allowances { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<InterServiceMark> InterServiceMarks { get; set; }
        public virtual ICollection<CourseGradingEntry> CourseGradingEntries { get; set; }
        public virtual ICollection<NewEntryEvaluation> NewEntryEvaluations { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<RoutineNote> RoutineNotes { get; set; }
        public virtual ICollection<IndividualBulletin> IndividualBulletins { get; set; }
        public virtual ICollection<IndividualNotice> IndividualNotices { get; set; }
        public virtual ICollection<TdecQuationGroup> TdecQuationGroups { get; set; }
        public virtual ICollection<CourseTask> CourseTasks { get; set; }
        public virtual ICollection<CourseSection> CourseSections { get; set; }
        public virtual ICollection<InstructorAssignment> InstructorAssignments { get; set; }
        public virtual ICollection<TraineeAssignmentSubmit> TraineeAssignmentSubmits { get; set; }
        public virtual ICollection<CourseBudgetAllocation> CourseBudgetAllocations { get; set; }
        public virtual ICollection<ForeignCourseOthersDocument> ForeignCourseOthersDocuments { get; set; }
        public virtual ICollection<CourseNomenee> CourseNomenees { get; set; }

        public virtual ICollection<GuestSpeakerQuationGroup> GuestSpeakerQuationGroups { get; set; }
        //public virtual ICollection<GuestSpeakerQuestionName> GuestSpeakerQuestionNames { get; set; }
    }
}
