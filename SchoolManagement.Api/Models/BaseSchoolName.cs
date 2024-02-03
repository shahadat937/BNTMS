using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BaseSchoolName
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
            CourseGradingEntries = new HashSet<CourseGradingEntry>();
            CourseInstructors = new HashSet<CourseInstructor>();
            CourseNomenees = new HashSet<CourseNomenee>();
            CourseModules = new HashSet<CourseModule>();
            CoursePlanCreates = new HashSet<CoursePlanCreate>();
            CourseSections = new HashSet<CourseSection>();
            CourseTasks = new HashSet<CourseTask>();
            CourseWeeks = new HashSet<CourseWeek>();
            Events = new HashSet<Event>();
            GuestSpeakerQuationGroups = new HashSet<GuestSpeakerQuationGroup>();
            IndividualBulletins = new HashSet<IndividualBulletin>();
            IndividualNotices = new HashSet<IndividualNotice>();
            NewEntryEvaluations = new HashSet<NewEntryEvaluation>();
            Notices = new HashSet<Notice>();
            NotificationReceivedBaseSchoolNames = new HashSet<Notification>();
            NotificationSendBaseSchoolNames = new HashSet<Notification>();
            ReadingMaterials = new HashSet<ReadingMaterial>();
            RoutineNotes = new HashSet<RoutineNote>();
            RoutineSoftCopyUploads = new HashSet<RoutineSoftCopyUpload>();
            SubjectMarks = new HashSet<SubjectMark>();
            TdecQuationGroups = new HashSet<TdecQuationGroup>();
            TraineeAssessmentCreates = new HashSet<TraineeAssessmentCreate>();
            TraineeAssessmentMarks = new HashSet<TraineeAssessmentMark>();
            TraineeAssignmentSubmits = new HashSet<TraineeAssignmentSubmit>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            TrainingObjectives = new HashSet<TrainingObjective>();
            TrainingSyllabi = new HashSet<TrainingSyllabus>();
        }

        public int BaseSchoolNameId { get; set; }
        public int? BaseNameId { get; set; }
        public string SchoolName { get; set; }
        public string ShortName { get; set; }
        public string SchoolLogo { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public int? BranchLevel { get; set; }
        public int? FirstLevel { get; set; }
        public int? SecondLevel { get; set; }
        public int? ThirdLevel { get; set; }
        public int? FourthLevel { get; set; }
        public int? FifthLevel { get; set; }
        public string ServerName { get; set; }
        public string SchoolHistory { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamInstructorAssign> BnaExamInstructorAssigns { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<BnaSubjectName> BnaSubjectNames { get; set; }
        public virtual ICollection<Bulletin> Bulletins { get; set; }
        public virtual ICollection<ClassPeriod> ClassPeriods { get; set; }
        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
        public virtual ICollection<CourseDuration> CourseDurations { get; set; }
        public virtual ICollection<CourseGradingEntry> CourseGradingEntries { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<CourseNomenee> CourseNomenees { get; set; }
        public virtual ICollection<CourseModule> CourseModules { get; set; }
        public virtual ICollection<CoursePlanCreate> CoursePlanCreates { get; set; }
        public virtual ICollection<CourseSection> CourseSections { get; set; }
        public virtual ICollection<CourseTask> CourseTasks { get; set; }
        public virtual ICollection<CourseWeek> CourseWeeks { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<GuestSpeakerQuationGroup> GuestSpeakerQuationGroups { get; set; }
        public virtual ICollection<IndividualBulletin> IndividualBulletins { get; set; }
        public virtual ICollection<IndividualNotice> IndividualNotices { get; set; }
        public virtual ICollection<NewEntryEvaluation> NewEntryEvaluations { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<Notification> NotificationReceivedBaseSchoolNames { get; set; }
        public virtual ICollection<Notification> NotificationSendBaseSchoolNames { get; set; }
        public virtual ICollection<ReadingMaterial> ReadingMaterials { get; set; }
        public virtual ICollection<RoutineNote> RoutineNotes { get; set; }
        public virtual ICollection<RoutineSoftCopyUpload> RoutineSoftCopyUploads { get; set; }
        public virtual ICollection<SubjectMark> SubjectMarks { get; set; }
        public virtual ICollection<TdecQuationGroup> TdecQuationGroups { get; set; }
        public virtual ICollection<TraineeAssessmentCreate> TraineeAssessmentCreates { get; set; }
        public virtual ICollection<TraineeAssessmentMark> TraineeAssessmentMarks { get; set; }
        public virtual ICollection<TraineeAssignmentSubmit> TraineeAssignmentSubmits { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<TrainingObjective> TrainingObjectives { get; set; }
        public virtual ICollection<TrainingSyllabus> TrainingSyllabi { get; set; }
    }
}
