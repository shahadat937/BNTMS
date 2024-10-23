using SchoolManagement.Domain.Common;


namespace SchoolManagement.Domain
{
    public class TraineeBioDataGeneralInfo : BaseDomainEntity
    {
        public TraineeBioDataGeneralInfo()
        {
            Attendances = new HashSet<Attendance>();
            BnaClassSchedules = new HashSet<BnaClassSchedule>();
            BnaClassTests = new HashSet<BnaClassTest>();
            BnaCurriculumUpdates = new HashSet<BnaCurriculumUpdate>();
            BnaExamAttendances = new HashSet<BnaExamAttendance>();
            BnaExamInstructorAssigns = new HashSet<BnaExamInstructorAssign>();
            BnaExamMarks = new HashSet<BnaExamMark>();
            BnaExamRoutineLogs = new HashSet<BnaExamRoutineLog>();
            BnaPromotionLogs = new HashSet<BnaPromotionLog>();
            ClassInstructorAssigns = new HashSet<ClassInstructorAssign>();
            CoCurricularActivities = new HashSet<CoCurricularActivity>();
            CourseInstructors = new HashSet<CourseInstructor>();
            CourseBudgetAllocations = new HashSet<CourseBudgetAllocation>();
            EducationalInstitutions = new HashSet<EducationalInstitution>();
            EducationalQualifications = new HashSet<EducationalQualification>();
            ForeignCourseOthersDocuments = new HashSet<ForeignCourseOthersDocument>();
            Elections = new HashSet<Election>();
            EmploymentBeforeJoinBnas = new HashSet<EmploymentBeforeJoinBna>();
            Favorites = new HashSet<Favorites>();
            FamilyNominations = new HashSet<FamilyNomination>();
            GameSports = new HashSet<GameSport>();
            GrandFathers = new HashSet<GrandFather>();
            InstallmentPaidDetails = new HashSet<InstallmentPaidDetail>();
            JoiningReasons = new HashSet<JoiningReason>();
            MigrationDocuments = new HashSet<MigrationDocument>();
            ParentRelatives = new HashSet<ParentRelative>();
            PaymentDetails = new HashSet<PaymentDetail>();
            Questions = new HashSet<Question>();
            SocialMedia = new HashSet<SocialMedia>();
            SwimmingDrivings = new HashSet<SwimmingDriving>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();
            TraineeLanguages = new HashSet<TraineeLanguage>();
            TraineeMemberships = new HashSet<TraineeMembership>();
            TraineeNominations = new HashSet<TraineeNomination>();
            TraineePictures = new HashSet<TraineePicture>();
            TraineeSectionSelections = new HashSet<TraineeSectionSelection>();
            TraineeVisitedAboards = new HashSet<TraineeVisitedAboard>();
            ExamCenterSelections = new HashSet<ExamCenterSelection>(); 
            InterServiceMarks = new HashSet<InterServiceMark>();
            FamilyInfos = new HashSet<FamilyInfo>();
            NewEntryEvaluations = new HashSet<NewEntryEvaluation>();
            TdecQuationGroups = new HashSet<TdecQuationGroup>();
            TraineeAssissmentGroups = new HashSet<TraineeAssissmentGroup>();
            TraineeAssignmentSubmitInstructors = new HashSet<TraineeAssignmentSubmit>();
            TraineeAssignmentSubmitTrainees = new HashSet<TraineeAssignmentSubmit>();
            ForeignCourseOtherDocs = new HashSet<ForeignCourseOtherDoc>();
            ForeignCourseOtherDocs = new HashSet<ForeignCourseOtherDoc>();
            IndividualNotices= new HashSet<IndividualNotice>();
            IndividualBulletins = new HashSet<IndividualBulletin>();
            InterServiceCourseReports = new HashSet<InterServiceCourseReport>();
            GuestSpeakerQuationGroups = new HashSet<GuestSpeakerQuationGroup>();
            RecordOfServices = new HashSet<RecordOfService>();
            MilitaryTrainings = new HashSet<MilitaryTraining>();
            CovidVaccines = new HashSet<CovidVaccine>();
            ForeignTrainingCourseReports = new HashSet<ForeignTrainingCourseReport>();
            //GuestSpeakerQuestionNames = new HashSet<GuestSpeakerQuestionName>();
            CourseNomenees = new HashSet<CourseNomenee>();

        }

        public int TraineeId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? RankId { get; set; }
        public int? BranchId { get; set; }
        public int? DivisionId { get; set; }
        public int? DistrictId { get; set; }
        public int? ThanaId { get; set; }
        public string? HeightId { get; set; }
        public string? WeightId { get; set; }
        public int? OfficerTypeId { get; set; }
        public int? ColorOfEyeId { get; set; }
        public int? GenderId { get; set; }
        public int? BloodGroupId { get; set; }
        public int? NationalityId { get; set; }
        public int? CountryId { get; set; }
        public int? ReligionId { get; set; }
        public int? CasteId { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? HairColorId { get; set; }
        public int? SaylorBranchId { get; set; }
        public int? SaylorRankId { get; set; }
        public int? SaylorSubBranchId { get; set; }
        public string? Name { get; set; }
        public string? NickName { get; set; }
        public string? NameBangla { get; set; }
        public string? ChestNo { get; set; }
        public string? LocalNo { get; set; }
        public string? IdCardNo { get; set; }
        public string? ShoeSize { get; set; }
        public string? PantSize { get; set; }
        public string? Nominee { get; set; }
        public string? CloseRelative { get; set; }
        public string? RelativeRelation { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? BnaPhotoUrl { get; set; }
        public string? BnaNo { get; set; }
        public string? Pno { get; set; }
        public string? ShortCode { get; set; }
        public string? PresentBillet { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? IdentificationMark { get; set; }
        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public int? TraineeStatusId { get; set; }
        public string? PassportNo { get; set; }
        public string? Nid { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? LocalNominationStatus { get; set; }

        public string? Seniority { get; set; }
        public string? Place { get; set; }
        public string? MedicalCategory { get; set; }
        public DateTime? MarriedDate { get; set; }
        public string? FamilyLocation { get; set; }
        public string? NameofWife { get; set; }
        public string? BankAccount { get; set; }
        public string? EmergencyCommunicatePerson { get; set; }
        public string? CountryVisited { get; set; }
        public string? Dislikeness { get; set; }
        public string? Likeness { get; set; }
        public string? Hobbies { get; set; }
        public string? Sports { get; set; }

        public virtual BloodGroup? BloodGroup { get; set; }
        public virtual BnaBatch? BnaBatch { get; set; }
        public virtual Branch? Branch { get; set; }
        public virtual Caste? Caste { get; set; }
        public virtual ColorOfEye? ColorOfEye { get; set; }
        public virtual District? District { get; set; }
        public virtual Division? Division { get; set; }
        public virtual Gender? Gender { get; set; }
        public virtual HairColor? HairColor { get; set; }
        public virtual SaylorBranch? SaylorBranch { get; set; }
        public virtual SaylorRank? SaylorRank { get; set; }
        public virtual SaylorSubBranch? SaylorSubBranch { get; set; }
        //public virtual Height? Height { get; set; }
        public virtual MaritalStatus? MaritalStatus { get; set; }
        public virtual Nationality? Nationality { get; set; }
        public virtual Country? Country { get; set; }
        public virtual Rank? Rank { get; set; }
        public virtual Religion? Religion { get; set; }
        public virtual Thana? Thana { get; set; }
        public virtual TraineeStatus? TraineeStatus { get; set; }
        //public virtual Weight? Weight { get; set; }


        public virtual ICollection<ForeignCourseOtherDoc> ForeignCourseOtherDocs { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; } 
        public virtual ICollection<BnaClassSchedule> BnaClassSchedules { get; set; }
        public virtual ICollection<BnaClassTest> BnaClassTests { get; set; }
        public virtual ICollection<BnaCurriculumUpdate> BnaCurriculumUpdates { get; set; }
        public virtual ICollection<BnaExamAttendance> BnaExamAttendances { get; set; }
        public virtual ICollection<BnaExamInstructorAssign> BnaExamInstructorAssigns { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<RecordOfService> RecordOfServices { get; set; }
        public virtual ICollection<InterServiceCourseReport> InterServiceCourseReports { get; set; }
        public virtual ICollection<BnaExamRoutineLog> BnaExamRoutineLogs { get; set; }
        public virtual ICollection<BnaPromotionLog> BnaPromotionLogs { get; set; }
        public virtual ICollection<ClassInstructorAssign> ClassInstructorAssigns { get; set; }
        public virtual ICollection<CoCurricularActivity> CoCurricularActivities { get; set; }
        public virtual ICollection<CourseBudgetAllocation> CourseBudgetAllocations { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<EducationalInstitution> EducationalInstitutions { get; set; }
        public virtual ICollection<EducationalQualification> EducationalQualifications { get; set; }
        public virtual ICollection<Election> Elections { get; set; }
        public virtual ICollection<EmploymentBeforeJoinBna> EmploymentBeforeJoinBnas { get; set; }
        public virtual ICollection<Favorites> Favorites { get; set; }
        public virtual ICollection<FamilyNomination> FamilyNominations { get; set; }
        public virtual ICollection<GameSport> GameSports { get; set; }
        public virtual ICollection<TraineeAssissmentGroup> TraineeAssissmentGroups { get; set; }
        public virtual ICollection<GrandFather> GrandFathers { get; set; }
        public virtual ICollection<InstallmentPaidDetail> InstallmentPaidDetails { get; set; }
        public virtual ICollection<JoiningReason> JoiningReasons { get; set; }
        public virtual ICollection<MigrationDocument> MigrationDocuments { get; set; }
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<SocialMedia> SocialMedia { get; set; }
        public virtual ICollection<SwimmingDriving> SwimmingDrivings { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }
        public virtual ICollection<TraineeLanguage> TraineeLanguages { get; set; }
        public virtual ICollection<TraineeMembership> TraineeMemberships { get; set; }
        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
        public virtual ICollection<TraineePicture> TraineePictures { get; set; }
        public virtual ICollection<TraineeSectionSelection> TraineeSectionSelections { get; set; }
        public virtual ICollection<TraineeVisitedAboard> TraineeVisitedAboards { get; set; }
        public virtual ICollection<ExamCenterSelection> ExamCenterSelections { get; set; }
        public virtual ICollection<InterServiceMark> InterServiceMarks { get; set; }
        public virtual ICollection<FamilyInfo> FamilyInfos { get; set; }
        public virtual ICollection<NewEntryEvaluation> NewEntryEvaluations { get; set; }
        public virtual ICollection<TdecQuationGroup> TdecQuationGroups { get; set; }
        public virtual ICollection<TraineeAssignmentSubmit> TraineeAssignmentSubmitInstructors { get; set; }
        public virtual ICollection<TraineeAssignmentSubmit> TraineeAssignmentSubmitTrainees { get; set; }
        public virtual ICollection<ForeignCourseOthersDocument> ForeignCourseOthersDocuments { get; set; }
        public virtual ICollection<IndividualNotice> IndividualNotices { get; set; }
        public virtual ICollection<IndividualBulletin> IndividualBulletins { get; set; }
        public virtual ICollection<GuestSpeakerQuationGroup> GuestSpeakerQuationGroups { get; set; }
        public virtual ICollection<MilitaryTraining> MilitaryTrainings { get; set; }
        public virtual ICollection<CovidVaccine> CovidVaccines { get; set; }
        public virtual ICollection<ForeignTrainingCourseReport> ForeignTrainingCourseReports { get; set; }
        public virtual ICollection<CourseNomenee> CourseNomenees { get; set; }

        //public virtual ICollection<GuestSpeakerQuestionName> GuestSpeakerQuestionNames { get; set; }
    }
}
