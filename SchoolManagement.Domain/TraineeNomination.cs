using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class TraineeNomination : BaseDomainEntity
    {
        public TraineeNomination()
        {
            BnaExamMarks = new HashSet<BnaExamMark>();
            ExamCenterSelections = new HashSet<ExamCenterSelection>();
            FamilyNominations = new HashSet<FamilyNomination>();
            ForeignCourseOtherDocs = new HashSet<ForeignCourseOtherDoc>();
            IndividualNotices = new HashSet<IndividualNotice>();
            IndividualBulletins = new HashSet<IndividualBulletin>();
            InterServiceMarks = new HashSet<InterServiceMark>();
            MigrationDocuments = new HashSet<MigrationDocument>();
            NewEntryEvaluations = new HashSet<NewEntryEvaluation>();
            Notices = new HashSet<Notice>();
            CourseNomenees = new HashSet<CourseNomenee>();
            TdecGroupResults = new HashSet<TdecGroupResult>();
            TraineeAssissmentGroups = new HashSet<TraineeAssissmentGroup>();
            GuestSpeakerGroupResults = new HashSet<GuestSpeakerGroupResult>();
        }

        public int TraineeNominationId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? DepartmentId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? ExamAttemptTypeId { get; set; }
        public int? ExamTypeId { get; set; }
        public int? TraineeId { get; set; }
        public int? ExamCenterId { get; set; }
        public int? NewAtemptId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? TraineeCourseStatusId { get; set; }
        public int? WithdrawnDocId { get; set; }
        public int? SaylorRankId { get; set; }
        public int? RankId { get; set; }
        public int? SaylorBranchId { get; set; }
        public int? SaylorSubBranchId { get; set; }
        public int? BranchId { get; set; }
        public int? CourseAttendState { get; set; }
        public string? CourseAttendStateRemark { get; set; }
        public string? CertificateSerialNo { get; set; }
        public string? IndexNo { get; set; }
        public string? PresentBillet { get; set; }
        public string? FamilyAllowId { get; set; }
        public string? WithdrawnRemarks { get; set; }
        public DateTime? WithdrawnDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; } 
        public bool IsActive { get; set; }
        public string? WithdrawnDocs { get; set; }
        public int? WithdrawnTypeId { get; set; }

        public virtual Branch? Branch { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
        public virtual CourseName? CourseName { get; set; }
        public virtual ExamAttemptType? ExamAttemptType { get; set; }
        public virtual ExamCenter? ExamCenter { get; set; }
        public virtual ExamType? ExamType { get; set; }
        public virtual NewAtempt? NewAtempt { get; set; }
        public virtual Rank? Rank { get; set; }
        public virtual SaylorBranch? SaylorBranch { get; set; }
        public virtual SaylorRank? SaylorRank { get; set; }
        public virtual SaylorSubBranch? SaylorSubBranch { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
        public virtual TraineeCourseStatus? TraineeCourseStatus { get; set; }
        public virtual WithdrawnDoc? WithdrawnDoc { get; set; } 
        public virtual WithdrawnType? WithdrawnType { get; set; }
        public virtual BnaSemesterDuration? BnaSemesterDuration { get; set; }
        public virtual Department? Department { get; set; }
        public virtual BnaSubjectCurriculum? BnaSubjectCurriculum { get; set; }

        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<ExamCenterSelection> ExamCenterSelections { get; set; }
        public virtual ICollection<FamilyNomination> FamilyNominations { get; set; }
        public virtual ICollection<ForeignCourseOtherDoc> ForeignCourseOtherDocs { get; set; }
        public virtual ICollection<IndividualNotice> IndividualNotices { get; set; }
        public virtual ICollection<IndividualBulletin> IndividualBulletins { get; set; }
        public virtual ICollection<InterServiceMark> InterServiceMarks { get; set; }
        public virtual ICollection<MigrationDocument> MigrationDocuments { get; set; }
        public virtual ICollection<NewEntryEvaluation> NewEntryEvaluations { get; set; }
        public virtual ICollection<Notice> Notices { get; set; }
        public virtual ICollection<TdecGroupResult> TdecGroupResults { get; set; }
        public virtual ICollection<TraineeAssissmentGroup> TraineeAssissmentGroups { get; set; }
        public virtual ICollection<GuestSpeakerGroupResult> GuestSpeakerGroupResults { get; set; }
        public virtual ICollection<CourseNomenee> CourseNomenees { get; set; }

    }
}
