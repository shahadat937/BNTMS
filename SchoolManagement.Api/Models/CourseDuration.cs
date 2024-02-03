using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class CourseDuration : BaseDomainEntity
    {
        public CourseDuration()
        {
            Attendances = new HashSet<Attendance>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
            BnaExamInstructorAssigns = new HashSet<BnaExamInstructorAssign>();
            BnaExamMarks = new HashSet<BnaExamMark>();
            Bulletins = new HashSet<Bulletin>();
            ClassRoutines = new HashSet<ClassRoutine>();
            CourseInstructors = new HashSet<CourseInstructor>();
            CourseNomenees = new HashSet<CourseNomenee>();

            CoursePlanCreates = new HashSet<CoursePlanCreate>();
            CourseBudgetAllocations = new HashSet<CourseBudgetAllocation>();
            CourseWeeks = new HashSet<CourseWeek>();
            Documents = new HashSet<Document>();
            Events = new HashSet<Event>();
            FamilyNominations = new HashSet<FamilyNomination>();
            ForeignCourseOthersDocuments = new HashSet<ForeignCourseOthersDocument>();
            InstallmentPaidDetails = new HashSet<InstallmentPaidDetail>();
            MigrationDocuments = new HashSet<MigrationDocument>();
            TraineeNominations = new HashSet<TraineeNomination>();
            InterServiceMarks = new HashSet<InterServiceMark>();
            NewEntryEvaluations = new HashSet<NewEntryEvaluation>();
            Notices = new HashSet<Notice>();
            IndividualBulletins = new HashSet<IndividualBulletin>();
            IndividualNotices = new HashSet<IndividualNotice>();
            TdecQuationGroups = new HashSet<TdecQuationGroup>();
            CourseTasks = new HashSet<CourseTask>();
            RoutineNotes = new HashSet<RoutineNote>();
            TrainingObjectives = new HashSet<TrainingObjective>();
            TrainingSyllabi = new HashSet<TrainingSyllabus>();
            InstructorAssignments = new HashSet<InstructorAssignment>();
            TraineeAssessmentCreates = new HashSet<TraineeAssessmentCreate>();
            TraineeAssissmentGroups = new HashSet<TraineeAssissmentGroup>();
            TraineeAssignmentSubmits = new HashSet<TraineeAssignmentSubmit>();
            ForeignCourseOtherDocs = new HashSet<ForeignCourseOtherDoc>();
            ForeignCourseGOInfos = new HashSet<ForeignCourseGOInfo>();
            InterServiceCourseReports = new HashSet<InterServiceCourseReport>();
            RoutineSoftCopyUploads = new HashSet<RoutineSoftCopyUpload>();
            GuestSpeakerQuationGroups = new HashSet<GuestSpeakerQuationGroup>();
            ForeignTrainingCourseReports = new HashSet<ForeignTrainingCourseReport>();
            BnaSemesterDurations = new HashSet<BnaSemesterDuration>();
            // GuestSpeakerQuestionNames = new HashSet<GuestSpeakerQuestionName>();
        }

        public int CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? BaseNameId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? CountryId { get; set; }
        public int? OrganizationNameId { get; set; }
        public int? FiscalYearId { get; set; }
        public string? CourseTitle { get; set; }
        public string? NoOfCandidates { get; set; }
        public DateTime? DurationFrom { get; set; }
        public DateTime? DurationTo { get; set; }
        public string? Professional { get; set; }
        public string? Nbcd { get; set; }
        public string? Remark { get; set; }
        public int? IsCompletedStatus { get; set; }
        public int? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? NbcdSchoolId { get; set; }
        public DateTime? NbcdDurationFrom { get; set; }
        public DateTime? NbcdDurationTo { get; set; }
        public int? NbcdStatus { get; set; }
        public int? ComeFromNbcdDurationId { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual Country? Country { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual CourseType? CourseType { get; set; }
        // public virtual BaseSchoolName NbcdSchool { get; set; }
        public virtual OrganizationName? OrganizationName { get; set; }
        public virtual FiscalYear? FiscalYear { get; set; }

        public virtual ICollection<InterServiceCourseReport> InterServiceCourseReports { get; set; }
        public virtual ICollection<ForeignCourseGOInfo> ForeignCourseGOInfos { get; set; }
        public virtual ICollection<ForeignCourseOtherDoc> ForeignCourseOtherDocs { get; set; }
        public virtual ICollection<TrainingSyllabus> TrainingSyllabi { get; set; }
        public virtual ICollection<TrainingObjective> TrainingObjectives { get; set; }
        public virtual ICollection<CourseTask> CourseTasks { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<ForeignTrainingCourseReport> ForeignTrainingCourseReports { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamInstructorAssign> BnaExamInstructorAssigns { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<Bulletin> Bulletins { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<CourseNomenee> CourseNomenees { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<InstallmentPaidDetail> InstallmentPaidDetails { get; set; }
        public virtual ICollection<CoursePlanCreate> CoursePlanCreates { get; set; }
        public virtual ICollection<CourseWeek> CourseWeeks { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<FamilyNomination> FamilyNominations { get; set; }
        public virtual ICollection<MigrationDocument> MigrationDocuments { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
        public virtual ICollection<InterServiceMark> InterServiceMarks { get; set; }
        public virtual ICollection<NewEntryEvaluation> NewEntryEvaluations { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<IndividualBulletin> IndividualBulletins { get; set; }
        public virtual ICollection<IndividualNotice> IndividualNotices { get; set; }
        public virtual ICollection<TdecQuationGroup> TdecQuationGroups { get; set; }
        public virtual ICollection<InstructorAssignment> InstructorAssignments { get; set; }
        public virtual ICollection<TraineeAssessmentCreate> TraineeAssessmentCreates { get; set; }
        public virtual ICollection<TraineeAssissmentGroup> TraineeAssissmentGroups { get; set; }
        public virtual ICollection<TraineeAssignmentSubmit> TraineeAssignmentSubmits { get; set; }
        public virtual ICollection<CourseBudgetAllocation> CourseBudgetAllocations { get; set; }
        public virtual ICollection<ForeignCourseOthersDocument> ForeignCourseOthersDocuments { get; set; }
        public virtual ICollection<RoutineNote> RoutineNotes { get; set; }
        public virtual ICollection<RoutineSoftCopyUpload> RoutineSoftCopyUploads { get; set; }
        public virtual ICollection<GuestSpeakerQuationGroup> GuestSpeakerQuationGroups { get; set; }
        public virtual ICollection<BnaSemesterDuration> BnaSemesterDurations { get; set; }
        // public virtual ICollection<GuestSpeakerQuestionName> GuestSpeakerQuestionNames { get; set; }
    }
}
