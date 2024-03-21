﻿using static SchoolManagement.Shared.Constants;

namespace SchoolManagement.Application
{
    public static class SMSRoutePrefix
    {
        private const string SMSRoutePrefixBase = ApiRoutePrefix.RoutePrefixBase + "sms/";
         
        //public const string Account = SMSRoutePrefixBase + "account";
        public const string AdminAuthority = SMSRoutePrefixBase + "admin-authority";
        public const string AllowancePercentage = SMSRoutePrefixBase + "allowance-percentage";
        public const string Allowance = SMSRoutePrefixBase + "allowance";
        public const string Assessment = SMSRoutePrefixBase + "assessment";
        public const string AssignmentMarkEntry = SMSRoutePrefixBase + "assignment-mark-entry";
        public const string AllowanceCategory = SMSRoutePrefixBase + "allowance-category";
        public const string BnaAttendancePeriod = SMSRoutePrefixBase + "bna-attendance-period";
        public const string BnaClassTestType = SMSRoutePrefixBase + "bna-class-test-type";
        public const string BnaClassTest = SMSRoutePrefixBase + "bna-class-test";
        public const string Attendance = SMSRoutePrefixBase + "attendance";
        public const string BaseName = SMSRoutePrefixBase + "base-name";
        public const string InterServiceCourseReport = SMSRoutePrefixBase + "inter-service-course-report";
        public const string SaylorBranch = SMSRoutePrefixBase + "saylor-branch";
        public const string SaylorRank = SMSRoutePrefixBase + "saylor-rank";
        public const string SaylorSubBranch = SMSRoutePrefixBase + "saylor-sub-branch";
        public const string BaseSchoolNames = SMSRoutePrefixBase + "base-School-name";
        public const string BloodGroup = SMSRoutePrefixBase + "blood-group";
        public const string BnaAttendanceRemarks = SMSRoutePrefixBase + "bna-attendance-remark";
        public const string BnaBatch = SMSRoutePrefixBase + "bna-batch";
        public const string BnaClassScheduleStatuses = SMSRoutePrefixBase + "bna-class-schedule-status";
        public const string BnaClassSectionSelection = SMSRoutePrefixBase + "bna-class-section-selection";
        public const string BnaCurriculamType = SMSRoutePrefixBase + "bna-curriculam-type";
        public const string BnaExamAttendance = SMSRoutePrefixBase + "bna-exam-attendance";
        public const string BnaExamInstructorAssign = SMSRoutePrefixBase + "bna-exam-instructor-assign";
        public const string BnaExamMark = SMSRoutePrefixBase + "bna-exam-mark";
        public const string BnaExamSchedule = SMSRoutePrefixBase + "bna-exam-schedule";
        public const string BnaInstructorType = SMSRoutePrefixBase + "bna-instructor-type";
        public const string BnaPromotionStatus = SMSRoutePrefixBase + "bna-promotion-status";
        public const string BnaSemesterDurations = SMSRoutePrefixBase + "bna-semester-duration";
        public const string BnaSemester = SMSRoutePrefixBase + "bna-semester";
        public const string BnaServiceType = SMSRoutePrefixBase + "bna-service-type";
        public const string BnaSubjectCurriculums = SMSRoutePrefixBase + "bna-subject-curriculum";
        public const string BnaSubjectName = SMSRoutePrefixBase + "bna-subject-name";
        public const string Board = SMSRoutePrefixBase + "board";
        public const string Notification = SMSRoutePrefixBase + "notification";
        public const string InterServiceCourseDocType = SMSRoutePrefixBase + "inter-service-course-doc-type";
        public const string Branch = SMSRoutePrefixBase + "branch";
        public const string UserManual = SMSRoutePrefixBase + "user-manual";
        public const string Bulletin = SMSRoutePrefixBase + "bulletin";
        public const string Caste = SMSRoutePrefixBase + "Caste";
        public const string ClassPeriod = SMSRoutePrefixBase + "class-period";
        public const string ClassRoutine = SMSRoutePrefixBase + "class-routine";
        public const string ClassType = SMSRoutePrefixBase + "class-type";
        public const string CoCurricularActivity = SMSRoutePrefixBase + "co-curricular-activity";
        public const string CoCurricularActivityType = SMSRoutePrefixBase + "co-curricular-activity-type";
        public const string CodeValues = SMSRoutePrefixBase + "code-value";
        public const string CodeValueType = SMSRoutePrefixBase + "code-value-type";
        public const string ColorOfEye = SMSRoutePrefixBase + "color-of-eye";
        public const string Complexion = SMSRoutePrefixBase + "complexion";
        public const string Country = SMSRoutePrefixBase + "country";
        public const string CourseTask = SMSRoutePrefixBase + "course-task";
        public const string CountryGroup = SMSRoutePrefixBase + "country-group";
        public const string CurrencyName = SMSRoutePrefixBase + "currency-name";
        public const string CourseGradingEntry = SMSRoutePrefixBase + "course-grading-entry";
        public const string CourseDurations = SMSRoutePrefixBase + "course-duration";
        public const string CourseInstructors = SMSRoutePrefixBase + "course-instructor";
        public const string CourseNomenees = SMSRoutePrefixBase + "course-Nomenee";
        public const string CourseModule = SMSRoutePrefixBase + "course-module";
        public const string CourseSection = SMSRoutePrefixBase + "course-section";
        public const string CourseName = SMSRoutePrefixBase + "course-name";
        public const string CoursePlan = SMSRoutePrefixBase + "course-plan";
        public const string CourseTypes = SMSRoutePrefixBase + "course-type";
        public const string CourseWeeks = SMSRoutePrefixBase + "course-week";
        public const string CourseWeekAll = SMSRoutePrefixBase + "courseWeekAll";
        public const string Dashboard = SMSRoutePrefixBase + "dashboard";
        public const string DefenseType = SMSRoutePrefixBase + "defense-type";
        public const string District = SMSRoutePrefixBase + "district";
        public const string Division = SMSRoutePrefixBase + "division";
        public const string Document = SMSRoutePrefixBase + "document";
        public const string DocumentTypes = SMSRoutePrefixBase + "document-type";
        public const string DownloadRight = SMSRoutePrefixBase + "download-right";
        public const string TraineeBioDataGeneralInfo = SMSRoutePrefixBase + "trainee-bio-data-general-info";
        public const string EducationalInstitution = SMSRoutePrefixBase + "educational-institution";
        public const string GameSport = SMSRoutePrefixBase + "game-sport";
        public const string EducationalQualification = SMSRoutePrefixBase + "educational-qualification";
        public const string Elected = SMSRoutePrefixBase + "elected";
        public const string Election = SMSRoutePrefixBase + "election";
        public const string EmploymentBeforeJoinBna = SMSRoutePrefixBase + "employment-before-join-bna";
        public const string Event = SMSRoutePrefixBase + "event";
        public const string ExamAttemptType = SMSRoutePrefixBase + "exam-attempt-type";
        public const string ExamCenter = SMSRoutePrefixBase + "exam-center";
        public const string ExamCenterSelection = SMSRoutePrefixBase + "exam-center-selection";
        public const string ExamMarkRemark = SMSRoutePrefixBase + "exam-mark-remark";
        public const string ExamPeriodType = SMSRoutePrefixBase + "exam-period-type"; 
        public const string ExamType = SMSRoutePrefixBase + "exam-type";
        public const string FailureStatus = SMSRoutePrefixBase + "failure-status";
        public const string FamilyInfo = SMSRoutePrefixBase + "family-info";
        public const string FamilyNomination = SMSRoutePrefixBase + "family-nomination";
        public const string Favorites = SMSRoutePrefixBase + "favorites";
        public const string FavoritesType = SMSRoutePrefixBase + "favorites-type";
        public const string FiscalYear = SMSRoutePrefixBase + "fiscal-year";
        public const string ForeignCourseGOInfo = SMSRoutePrefixBase + "foreign-course-go-info";
        public const string ForeignCourseOtherDoc = SMSRoutePrefixBase + "foreign-course-other-doc";
        public const string ForceType = SMSRoutePrefixBase + "force-type";
        public const string Game = SMSRoutePrefixBase + "game";
        public const string Gender = SMSRoutePrefixBase + "gender";
        public const string GrandFather = SMSRoutePrefixBase + "grand-father"; 
        public const string GrandFatherType = SMSRoutePrefixBase + "grand-father-type";
        public const string Group = SMSRoutePrefixBase + "group";
        public const string HairColor = SMSRoutePrefixBase + "hair-color";
        public const string Height = SMSRoutePrefixBase + "height";
        public const string InstallmentPaidDetail = SMSRoutePrefixBase + "installment-paid-detail";
        public const string InterServiceMark = SMSRoutePrefixBase + "inter-service-mark";
        public const string JoiningReason = SMSRoutePrefixBase + "joining-reason";
        public const string KindOfSubject = SMSRoutePrefixBase + "kind-of-subject";
        public const string Language = SMSRoutePrefixBase + "language";
        public const string WithdrawnDocs = SMSRoutePrefixBase + "withdrawn-docs";
        public const string Weights = SMSRoutePrefixBase + "weights";
        public const string UtofficerType = SMSRoutePrefixBase + "ut-officer-type";
        public const string UtofficerCategory = SMSRoutePrefixBase + "ut-officer-category";
        public const string WeekName = SMSRoutePrefixBase + "week-name";
        public const string TraineeVisitedAboard = SMSRoutePrefixBase + "trainee-visited-aboard";
        public const string TrainingObjective = SMSRoutePrefixBase + "training-objective";
        public const string TrainingSyllabus = SMSRoutePrefixBase + "training-syllabus";
        public const string TraineeNomination = SMSRoutePrefixBase + "trainee-nomination";
        public const string TraineeMembership = SMSRoutePrefixBase + "trainee-membership";
        public const string TraineeLanguage = SMSRoutePrefixBase + "trainee-language";
        public const string TraineeCourseStatuses = SMSRoutePrefixBase + "trainee-course-status";
        public const string TraineeBioDataOther = SMSRoutePrefixBase + "trainee-bio-data-other";
        public const string Thana = SMSRoutePrefixBase + "thana";
        public const string TdecActionStatus = SMSRoutePrefixBase + "tdec-action-status";
        public const string TdecGroupResult = SMSRoutePrefixBase + "tdec-group-result";
        public const string TdecQuestionName = SMSRoutePrefixBase + "tdec-question-name";
        public const string TdecQuationGroup = SMSRoutePrefixBase + "tdec-quation-group";
        public const string SwimmingDrivingLevel = SMSRoutePrefixBase + "swimming-driving-level";
        public const string SwimmingDriving = SMSRoutePrefixBase + "swimming-driving";
        public const string SubjectMark = SMSRoutePrefixBase + "subject-mark";
        public const string SubjectType = SMSRoutePrefixBase + "subject-type";
        public const string SubjectClassification = SMSRoutePrefixBase + "subject-classification";
        public const string SubjectCategory = SMSRoutePrefixBase + "subject-category";
        public const string StepRelation = SMSRoutePrefixBase + "step-relation";
        public const string SocialMediaType = SMSRoutePrefixBase + "social-media-type";
        public const string SocialMedia = SMSRoutePrefixBase + "social-media";
        public const string ShowRight = SMSRoutePrefixBase + "show-right";
        public const string WithdrawnType = SMSRoutePrefixBase + "Withdrawn-type";
        public const string ResultStatus = SMSRoutePrefixBase + "result-status";
        public const string Religion = SMSRoutePrefixBase + "religion";
        public const string RelationType = SMSRoutePrefixBase + "relation-type";
        public const string RoutineNote = SMSRoutePrefixBase + "routine-note";
        public const string ReasonType = SMSRoutePrefixBase + "reason-type";
        public const string ReadingMaterial = SMSRoutePrefixBase + "reading-material";
        public const string ReadingMaterialTitle = SMSRoutePrefixBase + "reading-material-title"; 
        public const string Ranks = SMSRoutePrefixBase + "ranks";
        public const string QuestionType = SMSRoutePrefixBase + "question-type";
        public const string Question = SMSRoutePrefixBase + "question";
        public const string PresentBillet = SMSRoutePrefixBase + "present-billet";
        public const string PaymentDetail = SMSRoutePrefixBase + "payment-detail";
        public const string ParentRelative = SMSRoutePrefixBase + "parent-relative";
        public const string Occupation = SMSRoutePrefixBase + "occupation";
        public const string OrganizationName = SMSRoutePrefixBase + "organization-name";
        public const string Nationality = SMSRoutePrefixBase + "nationality";
        public const string NewAtempt = SMSRoutePrefixBase + "new-atempt";
        public const string NewEntryEvaluation = SMSRoutePrefixBase + "new-entry-evaluation";
        public const string MembershipType = SMSRoutePrefixBase + "membership-type";
        public const string MigrationDocument = SMSRoutePrefixBase + "migration-document";
        public const string MaritalStatus = SMSRoutePrefixBase + "marital-status";
        public const string MarkType = SMSRoutePrefixBase + "mark-type";
        public const string AccountType = SMSRoutePrefixBase + "account-type";
        public const string BnaCurriculumUpdate = SMSRoutePrefixBase + "bna-curriculum-update";
        public const string TraineeSectionSelection = SMSRoutePrefixBase + "trainee-section-selection";
        public const string TraineeAssessmentMark = SMSRoutePrefixBase + "trainee-assessment-mark";
        public const string TraineeAssessmentCreate = SMSRoutePrefixBase + "trainee-assessment-create";
        public const string BnaClassAttendance = SMSRoutePrefixBase + "bna-class-attendance";
        public const string BnaClassSchedule = SMSRoutePrefixBase + "bna-class-schedule";
        public const string TraineePicture = SMSRoutePrefixBase + "trainee-picture";
        public const string Notice = SMSRoutePrefixBase + "notice"; 
        public const string IndividualNotice = SMSRoutePrefixBase + "individual-notice";
        public const string IndividualBulletin = SMSRoutePrefixBase + "individual-bulletin";
        public const string InstructorAssignment = SMSRoutePrefixBase + "instructor-assignments";
        public const string TraineeAssignmentSubmit = SMSRoutePrefixBase + "trainee-assignment-submit";
        public const string PaymentType = SMSRoutePrefixBase + "payment-type"; 
        public const string BudgetType = SMSRoutePrefixBase + "budget-type";  
        public const string BudgetCode = SMSRoutePrefixBase + "budget-code"; 
        public const string BudgetAllocation = SMSRoutePrefixBase + "budget-allocation"; 
        public const string CourseBudgetAllocation = SMSRoutePrefixBase + "course-budget-allocation"; 
        public const string ForeignCourseDocType = SMSRoutePrefixBase + "foreign-course-doctype"; 
        public const string ForeignCourseOthersDocument = SMSRoutePrefixBase + "foreign-course-others-document"; 
        public const string RoutineSoftCopyUpload = SMSRoutePrefixBase + "routine-softcopy-upload"; 
        public const string TraineeAssissmentGroup = SMSRoutePrefixBase + "trainee-assissment-group"; 

        public const string GuestSpeakerQuestionName = SMSRoutePrefixBase + "guest-speaker-question-name"; 
        public const string GuestSpeakerActionStatus = SMSRoutePrefixBase + "guest-speaker-action-atatus"; 

        public const string GuestSpeakerQuationGroup = SMSRoutePrefixBase + "guestspeaker-quationgroup"; 
        public const string RecordOfService = SMSRoutePrefixBase + "record-of-service"; 
        public const string MilitaryTraining = SMSRoutePrefixBase + "military-training"; 
        public const string CovidVaccine = SMSRoutePrefixBase + "covid-vaccine"; 
        public const string FinancialSanction = SMSRoutePrefixBase + "financial-sanction"; 
        public const string ForeignTrainingCourseReport = SMSRoutePrefixBase + "foreign-training-course-report"; 
        public const string Department = SMSRoutePrefixBase + "eepartment"; 
        public const string MarkCategory = SMSRoutePrefixBase + "mark-category"; 

        public const string BnaClassPeriod = SMSRoutePrefixBase + "bnaClass-period"; 
    }
} 
