using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.AdminAuthority;
using SchoolManagement.Application.DTOs.Attendance;
using SchoolManagement.Application.DTOs.BaseSchoolNames;
using SchoolManagement.Application.DTOs.BaseNames;
using SchoolManagement.Application.DTOs.BnaBatch;
using SchoolManagement.Application.DTOs.BnaAttendanceRemarks;
using SchoolManagement.Application.DTOs.BnaAttendancePeriod;
using SchoolManagement.Application.DTOs.BnaClassTest;
using SchoolManagement.Application.DTOs.BnaClassTestType;
using SchoolManagement.Application.DTOs.BnaCurriculamType;
using SchoolManagement.Application.DTOs.BnaClassScheduleStatuses;
using SchoolManagement.Application.DTOs.BnaClassSectionSelection;
using SchoolManagement.Application.DTOs.BnaExamAttendance;
using SchoolManagement.Application.DTOs.BnaExamInstructorAssign;
using SchoolManagement.Application.DTOs.BnaExamSchedule;
using SchoolManagement.Application.DTOs.BnaExamMark;
using SchoolManagement.Application.DTOs.BnaInstructorType;
using SchoolManagement.Application.DTOs.BnaPromotionStatus;
using SchoolManagement.Application.DTOs.BnaSemester;
using SchoolManagement.Application.DTOs.BnaSemesterDurations;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculums;
using SchoolManagement.Application.DTOs.BnaServiceType;
using SchoolManagement.Application.DTOs.BloodGroup;
using SchoolManagement.Application.DTOs.Board;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Bulletin;
using SchoolManagement.Application.DTOs.Caste;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.DTOs.ClassType;
using SchoolManagement.Application.DTOs.ColorOfEye;
using SchoolManagement.Application.DTOs.CourseName;
using SchoolManagement.Application.DTOs.CoCurricularActivity;
using SchoolManagement.Application.DTOs.CoCurricularActivityType;
using SchoolManagement.Application.DTOs.CodeValues;
using SchoolManagement.Application.DTOs.CodeValueType;
using SchoolManagement.Application.DTOs.Country;
using SchoolManagement.Application.DTOs.CoursePlan;
using SchoolManagement.Application.DTOs.CourseModule;
using SchoolManagement.Application.DTOs.CourseSection;
using SchoolManagement.Application.DTOs.CourseTypes;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.DTOs.CourseInstructors;
using SchoolManagement.Application.DTOs.CourseNomenees;
using SchoolManagement.Application.DTOs.DefenseType;
using SchoolManagement.Application.DTOs.District;
using SchoolManagement.Application.DTOs.Division;
using SchoolManagement.Application.DTOs.DocumentTypes;
using SchoolManagement.Application.DTOs.DownloadRight;
using SchoolManagement.Application.DTOs.EducationalInstitutions;
using SchoolManagement.Application.DTOs.EducationalQualification;
using SchoolManagement.Application.DTOs.Election;
using SchoolManagement.Application.DTOs.Electeds;
using SchoolManagement.Application.DTOs.EmploymentBeforeJoinBna;
using SchoolManagement.Application.DTOs.Event;
using SchoolManagement.Application.DTOs.ExamAttemptType;
using SchoolManagement.Application.DTOs.ExamType;
using SchoolManagement.Application.DTOs.ExamPeriodTypes;
using SchoolManagement.Application.DTOs.FamilyNomination;
using SchoolManagement.Application.DTOs.Favorites;
using SchoolManagement.Application.DTOs.FailureStatus;
using SchoolManagement.Application.DTOs.FavoritesType;
using SchoolManagement.Application.DTOs.Features;
using SchoolManagement.Application.DTOs.ForceType;
using SchoolManagement.Application.DTOs.Games;
using SchoolManagement.Application.DTOs.GameSport;
using SchoolManagement.Application.DTOs.Gender;
using SchoolManagement.Application.DTOs.GrandFather;
using SchoolManagement.Application.DTOs.GrandFatherType;
using SchoolManagement.Application.DTOs.Groups;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.DTOs.InstallmentPaidDetail;
using SchoolManagement.Application.DTOs.InterServiceMark;
using SchoolManagement.Application.DTOs.JoiningReasons;
using SchoolManagement.Application.DTOs.KindOfSubjects;
using SchoolManagement.Application.DTOs.Languages;
using SchoolManagement.Application.DTOs.MaritalStatus;
using SchoolManagement.Application.DTOs.MarkType;
using SchoolManagement.Application.DTOs.MembershipTypes;
using SchoolManagement.Application.DTOs.MigrationDocument;
using SchoolManagement.Application.DTOs.Modules;
using SchoolManagement.Application.DTOs.Nationality;
using SchoolManagement.Application.DTOs.Occupation;
using SchoolManagement.Application.DTOs.ParentRelative;
using SchoolManagement.Application.DTOs.PaymentDetail;
using SchoolManagement.Application.DTOs.PresentBillet;
using SchoolManagement.Application.DTOs.Question;
using SchoolManagement.Application.DTOs.QuestionType;
using SchoolManagement.Application.DTOs.Rank;
using SchoolManagement.Application.DTOs.Religion;
using SchoolManagement.Application.DTOs.RelationType;
using SchoolManagement.Application.DTOs.ReasonType;
using SchoolManagement.Application.DTOs.ResultStatus;
using SchoolManagement.Application.DTOs.ReadingMaterial;
using SchoolManagement.Application.DTOs.RoleFeature;
using SchoolManagement.Application.DTOs.SocialMediaTypes;
using SchoolManagement.Application.DTOs.SocialMedias;
using SchoolManagement.Application.DTOs.StepRelation;
using SchoolManagement.Application.DTOs.SubjectCategorys;
using SchoolManagement.Application.DTOs.SubjectMark;
using SchoolManagement.Application.DTOs.SubjectTypes;
using SchoolManagement.Application.DTOs.SubjectClassifications;
using SchoolManagement.Application.DTOs.SwimmingDriving;
using SchoolManagement.Application.DTOs.SwimmingDrivingLevel;
using SchoolManagement.Application.DTOs.Thana;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Application.DTOs.TraineeBioDataOther;
using SchoolManagement.Application.DTOs.TraineeCourseStatus;
using SchoolManagement.Application.DTOs.TraineeLanguages;
using SchoolManagement.Application.DTOs.TraineeMembership;
using SchoolManagement.Application.DTOs.TraineeNomination;
using SchoolManagement.Application.DTOs.TraineeVisitedAboard;
using SchoolManagement.Application.DTOs.UtofficerType;
using SchoolManagement.Application.DTOs.UtofficerCategory;
using SchoolManagement.Application.DTOs.Weight;
using SchoolManagement.Application.DTOs.WithdrawnDoc;
using SchoolManagement.Application.DTOs.ExamCenter;
using SchoolManagement.Application.DTOs.ExamCenterSelection;
using SchoolManagement.Application.DTOs.ExamMarkRemarks;
using SchoolManagement.Application.DTOs.HairColor;
using SchoolManagement.Application.DTOs.FiscalYears;
using SchoolManagement.Application.DTOs.AccountType;
using SchoolManagement.Application.DTOs.BnaCurriculumUpdate;
using SchoolManagement.Application.DTOs.TraineeSectionSelection;
using SchoolManagement.Application.DTOs.BnaClassSchedule;
using SchoolManagement.Application.DTOs.TraineePicture;
using SchoolManagement.Application.DTOs.CountryGroup;
using SchoolManagement.Application.DTOs.CurrencyName;
using SchoolManagement.Application.DTOs.AllowancePercentage;
using SchoolManagement.Application.DTOs.AllowanceCategory;
using SchoolManagement.Application.DTOs.Allowance;
using SchoolManagement.Application.DTOs.OrganizationName;
using SchoolManagement.Application.DTOs.FamilyInfo;
using SchoolManagement.Application.DTOs.ReadingMaterialTitles;
using SchoolManagement.Application.DTOs.NewAtempt;
using SchoolManagement.Application.Helpers;
using SchoolManagement.Application.DTOs.Assessment;
using SchoolManagement.Application.DTOs.CourseGradingEntry;
using SchoolManagement.Application.DTOs.WeekName;
using SchoolManagement.Application.DTOs.NewEntryEvaluation;
using SchoolManagement.Application.DTOs.Notice;
using SchoolManagement.Application.DTOs.IndividualNotice;
using SchoolManagement.Application.DTOs.IndividualNotices;
using SchoolManagement.Application.DTOs.IndividualBulletin;
using SchoolManagement.Application.DTOs.IndividualBulletins;
using SchoolManagement.Application.DTOs.TdecActionStatus;
using SchoolManagement.Application.DTOs.TdecQuestionName;
using SchoolManagement.Application.DTOs.TdecQuationGroup;
using SchoolManagement.Application.DTOs.CourseTask;
using SchoolManagement.Application.DTOs.TrainingObjective;
using SchoolManagement.Application.DTOs.TrainingSyllabus;
using SchoolManagement.Application.DTOs.TdecQuationGroup.CreateTdecQuationGroup;
using SchoolManagement.Application.DTOs.TdecGroupResult;
using SchoolManagement.Application.DTOs.InstructorAssignments;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits;
using SchoolManagement.Application.DTOs.PaymentType;
using SchoolManagement.Application.DTOs.BudgetType;
using SchoolManagement.Application.DTOs.BudgetCode;
using SchoolManagement.Application.DTOs.BudgetAllocation;
using SchoolManagement.Application.DTOs.CourseBudgetAllocation;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc;
using SchoolManagement.Application.DTOs.ForeignCourseGOInfo;
using SchoolManagement.Application.DTOs.ForeignCourseDocType;
using SchoolManagement.Application.DTOs.ForeignCourseOthersDocument;
using SchoolManagement.Application.DTOs.RoutineNote;
using SchoolManagement.Application.DTOs.SaylorBranch;
using SchoolManagement.Application.DTOs.SaylorRank;
using SchoolManagement.Application.DTOs.SaylorSubBranch;
using SchoolManagement.Application.DTOs.AssignmentMarkEntry;
using SchoolManagement.Application.DTOs.Document;
using SchoolManagement.Application.DTOs.InterServiceCourseDocType;
using SchoolManagement.Application.DTOs.InterServiceCourseReport;
using SchoolManagement.Application.DTOs.UserManual;
using SchoolManagement.Application.DTOs.WithdrawnType;
using SchoolManagement.Application.DTOs.Notification;
using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload;
using SchoolManagement.Application.DTOs.TraineeAssessmentMark;
using SchoolManagement.Application.DTOs.TraineeAssessmentCreate;
using SchoolManagement.Application.DTOs.TraineeAssissmentGroup;
using SchoolManagement.Application.DTOs.GuestSpeakerQuestionName;
using SchoolManagement.Application.DTOs.GuestSpeakerActionStatus;
using SchoolManagement.Application.DTOs.GuestSpeakerQuationGroup;
using SchoolManagement.Application.DTOs.RecordOfService;
using SchoolManagement.Application.DTOs.MilitaryTraining;
using SchoolManagement.Application.DTOs.CovidVaccine;
using SchoolManagement.Application.DTOs.ForeignTrainingCourseReport;
using SchoolManagement.Application.DTOs.FinancialSanction;
using SchoolManagement.Application.DTOs.Department;
using SchoolManagement.Application.DTOs.MarkCategory;
using SchoolManagement.Application.DTOs.BnaClassPeriod;
using SchoolManagement.Application.DTOs.BnaClassAttrendance;
using SchoolManagement.Application.DTOs.CourseLevel;
using SchoolManagement.Application.DTOs.CourseTerm;
using SchoolManagement.Application.DTOs.UniversityCourseResult;

namespace SchoolManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Lattar A
            CreateMap<BnaClassRoutine, SchoolManagement.Application.DTOs.BnaClassRoutines.BnaClassRoutineDto>().ReverseMap();

            CreateMap<CourseWeekAll, SchoolManagement.Application.DTOs.CourseWeekAll.CourseWeekAllDto>().ReverseMap();
            CreateMap<CourseWeekAll, SchoolManagement.Application.DTOs.CourseWeekAll.CreateCourseWeekAllDto>().ReverseMap();

            #region AccountType Mapping    
            CreateMap<AccountType, AccountTypeDto>().ReverseMap();
            CreateMap<AccountType, CreateAccountTypeDto>().ReverseMap();
            #endregion

            #region AdminAuthority Mapping    
            CreateMap<AdminAuthority, AdminAuthorityDto>().ReverseMap();
            CreateMap<AdminAuthority, CreateAdminAuthorityDto>().ReverseMap();
            #endregion

            #region Allowance Mapping    
            CreateMap<AllowanceDto, Allowance>().ReverseMap()
                .ForMember(d => d.FromRank, o => o.MapFrom(s => s.FromRank.RankName))
                .ForMember(d => d.ToRank, o => o.MapFrom(s => s.ToRank.RankName))
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.CountryName))
                .ForMember(d => d.AllowanceCategory, o => o.MapFrom(s => s.AllowanceCategory.AllowancePercentage.AllowanceName))
                .ForMember(d => d.AllowancePercentageId, o => o.MapFrom(s => s.AllowanceCategory.AllowancePercentage.AllowancePercentageId))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course));
            CreateMap<Allowance, CreateAllowanceDto>().ReverseMap();
            #endregion

            #region AllowanceCategory Mapping    
            CreateMap<AllowanceCategoryDto, AllowanceCategory>().ReverseMap()
                .ForMember(d => d.FromRank, o => o.MapFrom(s => s.FromRank.RankName))
                .ForMember(d => d.ToRank, o => o.MapFrom(s => s.ToRank.RankName))
                .ForMember(d => d.CountryGroup, o => o.MapFrom(s => s.CountryGroup.Name))
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.CountryName))
                .ForMember(d => d.CurrencyName, o => o.MapFrom(s => s.CurrencyName.Name))
                .ForMember(d => d.AllowancePercentage, o => o.MapFrom(s => s.AllowancePercentage.AllowanceName+"-"+s.AllowancePercentage.Percentage));
            CreateMap<AllowanceCategory, CreateAllowanceCategoryDto>().ReverseMap();
            #endregion

            #region AllowancePercentage Mapping    
            CreateMap<AllowancePercentage, AllowancePercentageDto>().ReverseMap();
            CreateMap<AllowancePercentage, CreateAllowancePercentageDto>().ReverseMap();
            #endregion

            #region Assessment Mapping    
            CreateMap<Assessment, AssessmentDto>().ReverseMap();
            CreateMap<Assessment, CreateAssessmentDto>().ReverseMap();
            #endregion

            #region AssignmentMarkEntry Mapping    
            CreateMap<AssignmentMarkEntry, AssignmentMarkEntryDto>().ReverseMap();
            CreateMap<AssignmentMarkEntry, CreateAssignmentMarkEntryDto>().ReverseMap();
            #endregion

            #region Attendance Mappings    
            CreateMap<AttendanceDto, Attendance>().ReverseMap()
                .ForMember(d => d.ClassRoutine, o => o.MapFrom(s => s.ClassRoutine.Date))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.ClassPeriod, o => o.MapFrom(s => s.ClassPeriod.PeriodName))
                .ForMember(d => d.BnaSubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.BnaAttendanceRemarks, o => o.MapFrom(s => s.BnaAttendanceRemarks.AttendanceRemarksCause))
                .ForMember(d => d.TraineeName, o => o.MapFrom(s => s.Trainee.Name))
                .ForMember(d => d.TraineePNo, o => o.MapFrom(s => s.Trainee.Pno))
                .ForMember(d => d.RankName, o => o.MapFrom(s => s.Trainee.Rank.RankName))
                .ForMember(d => d.RankPosition, o => o.MapFrom(s => s.Trainee.Rank.Position)); ;
            CreateMap<Attendance, CreateAttendanceDto>().ReverseMap();

            CreateMap<Attendance, CreateAttendanceListDto>().ReverseMap();

            //CreateMap<Contract.Dto.Result, List<Result>>(MemberList.Source).ConvertUsing<ResultConverter>();
            //CreateMap<Contract.Dto.Result, Result>(MemberList.Source);

            //CreateMap<AttendanceDto,Attendance>().ReverseMap()
            //    .ForMember(d=>d.BaseSchoolNameId,o=>o.MapFrom(s=>s.BaseSchoolNameId))
            //    .ForMember(d=>d.CourseNameId, o => o.MapFrom(s => s.CourseNameId))
            //    .ForMember(d=>d.ClassPeriodId, o => o.MapFrom(s => s.ClassPeriodId))
            //    .ForMember(d => d.AttendanceDate, o => o.MapFrom(s => s.AttendanceDate))
            //    .ForMember(d => d.ClassLeaderName, o => o.MapFrom(s => s.ClassLeaderName)) 
            //.ForMember()


            //      cfg.CreateMap<RemoteData, List<PriceDto>>()
            //          .ConvertUsing(source => source.Prices?.Select(p => new PriceDto
            //          {
            //              Ticker = source.Security?.Ticker,
            //              Open = p.Open,
            //              Close = p.Close
            //          }).ToList()
            //          );
            //  });

            // CreateMap<List<Attendance>, CreateAttendanceListDto>().ReverseMap();
            #endregion

            //Lattar B

            #region BaseNames Mapping 
            CreateMap<BaseNameDto, BaseName>().ReverseMap()
              .ForMember(d => d.AdminAuthority, o => o.MapFrom(s => s.AdminAuthority.AdminAuthorityName))
              .ForMember(d => d.Division, o => o.MapFrom(s => s.Division.DivisionName))
               .ForMember(d => d.District, o => o.MapFrom(s => s.District.DistrictName));

            CreateMap<BaseName, CreateBaseNameDto>().ReverseMap();
            #endregion


            #region BnaClassSchedule Mapping    
            CreateMap< BnaClassScheduleDto, BnaClassSchedule>().ReverseMap()
                .ForMember(d => d.BnaSemester, o => o.MapFrom(s => s.BnaSemester.SemesterName))
                .ForMember(d => d.ClassPeriod, o => o.MapFrom(s => s.ClassPeriod.PeriodName))
                .ForMember(d => d.BnaSubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.BnaClassSectionSelection, o => o.MapFrom(s => s.BnaClassSectionSelection.SectionName));
            CreateMap<BnaClassSchedule, CreateBnaClassScheduleDto>().ReverseMap();
            #endregion

            #region BnaExamMark Mappings      
            CreateMap<BnaExamMarkDto, BnaExamMark>().ReverseMap()
                .ForMember(d => d.TraineeName, o => o.MapFrom(s => s.Trainee.Name))
                .ForMember(d => d.TraineePNo, o => o.MapFrom(s => s.Trainee.Pno))
                .ForMember(d => d.TraineeNomination, o => o.MapFrom(s => s.TraineeNomination.IndexNo))
                .ForMember(d => d.SaylorRank, o => o.MapFrom(s => s.Trainee.SaylorRank.Name))
                .ForMember(d => d.RankPosition, o => o.MapFrom(s => s.Trainee.Rank.Position));

            CreateMap<BnaExamMark, CreateBnaExamMarkDto>().ReverseMap();
            #endregion

            #region BaseSchoolNames Mapping   
            CreateMap<BaseSchoolNameDto, BaseSchoolName>().ReverseMap()
              .ForMember(d => d.BaseName, o => o.MapFrom(s => s.BaseName.BaseNames))
              .ForMember(d => d.SchoolLogo, o => o.MapFrom<LogoUrlResolver>()); ;
            CreateMap<BaseSchoolName, CreateBaseSchoolNameDto>().ReverseMap();
            #endregion           

            #region BnaBatch Mappings
            CreateMap<BnaBatch, BnaBatchDto>().ReverseMap();
            CreateMap<BnaBatch, CreateBnaBatchDto>().ReverseMap();
            #endregion

            #region BnaAttendanceRemarks Mappings     
            CreateMap<BnaAttendanceRemarks, BnaAttendanceRemarkDto>().ReverseMap();
            CreateMap<BnaAttendanceRemarks, CreateBnaAttendanceRemarkDto>().ReverseMap();
            #endregion

            #region BnaAttendancePeriod Mappings     
            CreateMap<BnaAttendancePeriod, BnaAttendancePeriodDto>().ReverseMap();
            CreateMap<BnaAttendancePeriod, CreateBnaAttendancePeriodDto>().ReverseMap();
            #endregion

            #region BnaClassTestType Mappings     
            CreateMap<BnaClassTestType, BnaClassTestTypeDto>().ReverseMap();
            CreateMap<BnaClassTestType, CreateBnaClassTestTypeDto>().ReverseMap();
            #endregion
            
            #region BnaClassTest Mappings     
            CreateMap<BnaClassTestDto, BnaClassTest>().ReverseMap()
                .ForMember(d => d.BnaClassTestType, o => o.MapFrom(s => s.BnaClassTestType.Name))
                .ForMember(d => d.BnaSemester, o => o.MapFrom(s => s.BnaSemester.SemesterName))
                .ForMember(d => d.BnaSubjectCurriculum, o => o.MapFrom(s => s.BnaSubjectCurriculum.SubjectCurriculumName))
                .ForMember(d => d.BnaSubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.SubjectCategory, o => o.MapFrom(s => s.SubjectCategory.SubjectCategoryName));
            CreateMap<BnaClassTest, CreateBnaClassTestDto>().ReverseMap();
            #endregion

            #region BnaCurriculamType Mappings
            CreateMap<BnaCurriculumType, BnaCurriculamTypeDto>().ReverseMap();
            CreateMap<BnaCurriculumType, CreateBnaCurriculamTypeDto>().ReverseMap();
            #endregion

            #region BnaCurriculumUpdate Mapping    
            CreateMap<BnaCurriculumUpdateDto, BnaCurriculumUpdate>().ReverseMap()
                .ForMember(d => d.BnaBatch, o => o.MapFrom(s => s.BnaBatch.BatchName))
                .ForMember(d => d.BnaSemester, o => o.MapFrom(s => s.BnaSemester.SemesterName))
                .ForMember(d => d.BnaCurriculumType, o => o.MapFrom(s => s.BnaCurriculumType.CurriculumType));
            CreateMap<BnaCurriculumUpdate, CreateBnaCurriculumUpdateDto>().ReverseMap();
            #endregion

            #region BnaClassScheduleStatuss Mappings  
            CreateMap<BnaClassScheduleStatus, BnaClassScheduleStatusDto>().ReverseMap();
            CreateMap<BnaClassScheduleStatus, CreateBnaClassScheduleStatusDto>().ReverseMap();
            #endregion 

            #region BnaClassSection Mappings 
            CreateMap<BnaClassSectionSelection, BnaClassSectionSelectionDto>().ReverseMap();
            CreateMap<BnaClassSectionSelection, CreateBnaClassSectionSelectionDto>().ReverseMap();
            #endregion            

            #region BnaExamAttendance Mappings      
            CreateMap<BnaExamAttendanceDto, BnaExamAttendance>().ReverseMap()
                .ForMember(d => d.BnaSemester, o => o.MapFrom(s => s.BnaSemester.SemesterName))
                .ForMember(d => d.BnaBatch, o => o.MapFrom(s => s.BnaBatch.BatchName))
                .ForMember(d => d.ExamType, o => o.MapFrom(s => s.ExamType.ExamTypeName))
                .ForMember(d => d.BnaSubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName));
            CreateMap<BnaExamAttendance, CreateBnaExamAttendanceDto>().ReverseMap();
            #endregion

            #region BnaExamInstructorAssign Mappings   
            CreateMap<BnaExamInstructorAssignDto, BnaExamInstructorAssign>().ReverseMap()
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.BnaInstructorType, o => o.MapFrom(s => s.BnaInstructorType.InstructorTypeName))
                .ForMember(d => d.BnaSubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.ClassRoutine, o => o.MapFrom(s => s.ClassRoutine.Date))
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.CourseModule, o => o.MapFrom(s => s.CourseModule.ModuleName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.Trainee, o => o.MapFrom(s => s.Trainee.Name))
                .ForMember(d => d.TraineePno, o => o.MapFrom(s => s.Trainee.Pno))
                .ForMember(d => d.TraineeRank, o => o.MapFrom(s => s.Trainee.Rank.Position));
                

            CreateMap<BnaExamInstructorAssign, CreateBnaExamInstructorAssignDto>().ReverseMap();
            #endregion

            #region BnaExamSchedule Mappings   
            CreateMap<BnaExamScheduleDto, BnaExamSchedule>().ReverseMap()
                .ForMember(d => d.BnaBatch, o => o.MapFrom(s => s.BnaBatch.BatchName))
                .ForMember(d => d.BnaSubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.BnaSemester, o => o.MapFrom(s => s.BnaSemester.SemesterName))
                .ForMember(d => d.ExamType, o => o.MapFrom(s => s.ExamType.ExamTypeName));

            CreateMap<BnaExamSchedule, CreateBnaExamScheduleDto>().ReverseMap();
            #endregion

            #region BnaInstructorType Mappings 
            CreateMap<BnaInstructorType, BnaInstructorTypeDto>().ReverseMap();
            CreateMap<BnaInstructorType, CreateBnaInstructorTypeDto>().ReverseMap();
            #endregion

            #region BnaPromotionStatus  Mappings 
            CreateMap<BnaPromotionStatus, BnaPromotionStatusDto>().ReverseMap();
            CreateMap<BnaPromotionStatus, CreateBnaPromotionStatusDto>().ReverseMap();
            #endregion

            #region BnaSemester Mappings
            CreateMap<BnaSemester, BnaSemesterDto>().ReverseMap();
            CreateMap<BnaSemester, CreateBnaSemesterDto>().ReverseMap();
            #endregion

            #region BnaSemesterDuration Mapping                    
            CreateMap<BnaSemesterDurationDto, BnaSemesterDuration>().ReverseMap()
                .ForMember(d => d.BnaSemesterName, o => o.MapFrom(s => s.BnaSemester.SemesterName))
                .ForMember(d => d.BatchName, o => o.MapFrom(s => s.BnaBatch.BatchName))
                .ForMember(d => d.Rank, o => o.MapFrom(s => s.Rank.RankName))
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseName.Course + "-"+ s.CourseDuration.CourseTitle))
                .ForMember(d => d.LocationType, o => o.MapFrom(s => s.SemesterLocationTypeNavigation.TypeValue));
            CreateMap<BnaSemesterDuration, CreateBnaSemesterDurationDto>().ReverseMap();
            #endregion

            #region BnaSubjectName Mapping        
            CreateMap<BnaSubjectNameDto, BnaSubjectName>().ReverseMap()
                .ForMember(d => d.SubjectCategoryName, o => o.MapFrom(s => s.SubjectCategory.SubjectCategoryName))
                .ForMember(d => d.BnaSubjectCurriculum, o => o.MapFrom(s => s.BnaSubjectCurriculum.SubjectCurriculumName))
                .ForMember(d => d.SubjectType, o => o.MapFrom(s => s.SubjectType.SubjectTypeName))
                .ForMember(d => d.CourseModule, o => o.MapFrom(s => s.CourseModule.ModuleName))
                .ForMember(d => d.KindOfSubject, o => o.MapFrom(s => s.KindOfSubject.KindOfSubjectName))
                .ForMember(d => d.SubjectClassification, o => o.MapFrom(s => s.SubjectClassification.SubjectClassificationName))
                .ForMember(d => d.ResultStatus, o => o.MapFrom(s => s.ResultStatus.ResultStatusName))
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch.BranchName))
                .ForMember(d => d.SaylorBranch, o => o.MapFrom(s => s.SaylorBranch.Name))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course));

            CreateMap<BnaSubjectName, CreateBnaSubjectNameDto>().ReverseMap();
            #endregion

            #region BnaSubjectCurriculums Mapping    
            CreateMap<BnaSubjectCurriculum, BnaSubjectCurriculumDto>().ReverseMap();
            CreateMap<BnaSubjectCurriculum, CreateBnaSubjectCurriculumDto>().ReverseMap();
            #endregion

            #region BnaServiceType Mappings
            CreateMap<BnaServiceType, BnaServiceTypeDto>().ReverseMap();
            CreateMap<BnaServiceType, CreateBnaServiceTypeDto>().ReverseMap();
            #endregion

            #region BloodGroup Mappings 
            CreateMap<BloodGroup, BloodGroupDto>().ReverseMap();
            CreateMap<BloodGroup, CreateBloodGroupDto>().ReverseMap();
            #endregion

            #region Board Mappings
            CreateMap<Board, BoardDto>().ReverseMap();
            CreateMap<Board, CreateBoardDto>().ReverseMap();
            #endregion

            #region Notification Mappings
            CreateMap<Notification, NotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            #endregion

            #region BudgetType Mappings
            CreateMap<BudgetType, BudgetTypeDto>().ReverseMap();
            CreateMap<BudgetType, CreateBudgetTypeDto>().ReverseMap();
            #endregion
             
            #region BudgetCode Mappings
            CreateMap<BudgetCode, BudgetCodeDto>().ReverseMap();
            CreateMap<BudgetCode, CreateBudgetCodeDto>().ReverseMap();
            #endregion


            CreateMap<CourseWeekAllDto, CourseWeek>().ReverseMap()
               .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
               .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
               .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course));
            CreateMap<CourseWeek, CreateCourseWeekDto>().ReverseMap();

            #region BudgetAllocation Mappings
            CreateMap<BudgetAllocationDto, BudgetAllocation>().ReverseMap()
               .ForMember(d => d.BudgetCode, o => o.MapFrom(s => s.BudgetCode.Name))
               .ForMember(d => d.BudgetType, o => o.MapFrom(s => s.BudgetType.BudgetTypeName))
               .ForMember(d => d.FiscalYear, o => o.MapFrom(s => s.FiscalYear.FiscalYearName));
            CreateMap<BudgetAllocation, CreateBudgetAllocationDto>().ReverseMap();
            #endregion  


            #region Branch Mappings
            CreateMap<Branch, BranchDto>().ReverseMap();
            CreateMap<Branch, CreateBranchDto>().ReverseMap();
            #endregion

            #region Bulletin Mappings
            CreateMap<BulletinDto, Bulletin>().ReverseMap()
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course + "_" + s.CourseDuration.CourseTitle));
                //.ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course));


            CreateMap<Bulletin, CreateBulletinDto>().ReverseMap();
            #endregion

            //Lattar C

            #region Caste Mappings
            CreateMap<CasteDto, Caste>().ReverseMap()
              .ForMember(d => d.Religion, o => o.MapFrom(s => s.Religion.ReligionName));

            CreateMap<Caste, CreateCasteDto>().ReverseMap();
            #endregion

            #region ClassRoutine Mappings    
            CreateMap<ClassRoutineDto, ClassRoutine>().ReverseMap()
                .ForMember(d => d.ClassPeriod, o => o.MapFrom(s => s.ClassPeriod.PeriodName))
                .ForMember(d => d.ClassPeriodDurationForm, o => o.MapFrom(s => s.ClassPeriod.DurationForm))
                .ForMember(d => d.ClassPeriodDurationTo, o => o.MapFrom(s => s.ClassPeriod.DurationTo))
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.BnaSubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.ClassType, o => o.MapFrom(s => s.ClassType.ClassTypeName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch.BranchName))
                .ForMember(d => d.CourseModule, o => o.MapFrom(s => s.CourseModule.ModuleName))
                .ForMember(d => d.MarkType, o => o.MapFrom(s => s.MarkType.ShortName))
                .ForMember(d => d.CourseSection, o => o.MapFrom(s => s.CourseSection.SectionName))
                //.ForMember(d => d.ClassInstructorName, o => o.MapFrom(s => (s.InstructorBio.Pno + "_" + s.InstructorBio.Name)))
                .ForMember(d => d.Trainee, o => o.MapFrom(s => (s.Trainee.Pno + "_" + s.Trainee.Name)))
                .ForMember(d => d.CourseWeek, o => o.MapFrom(s => s.CourseWeek.WeekName));

            CreateMap<ClassRoutine, CreateClassRoutineDto>().ReverseMap();
            #endregion

            #region ClassPeriod Mappings   
            CreateMap<ClassPeriodDto, ClassPeriod>().ReverseMap()
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.BnaClassScheduleStatus, o => o.MapFrom(s => s.BnaClassScheduleStatus.Name))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course));

            CreateMap<ClassPeriod, CreateClassPeriodDto>().ReverseMap();
            #endregion

            #region ClassType  Mappings  
            CreateMap<ClassType, ClassTypeDto>().ReverseMap();
            CreateMap<ClassType, CreateClassTypeDto>().ReverseMap();
            #endregion

            #region ColorOfEye Mappings
            CreateMap<ColorOfEye, ColorOfEyeDto>().ReverseMap();
            CreateMap<ColorOfEye, CreateColorOfEyeDto>().ReverseMap();
            #endregion

            #region CourseName  Mappings 
            CreateMap<CourseNameDto, CourseName>().ReverseMap()
                 .ForMember(d => d.CourseTypeName, o => o.MapFrom(s => s.CourseType.CourseTypeName))
                 .ForMember(d => d.CourseSyllabus, o => o.MapFrom<FileCourseUrlResolver>());

            CreateMap<CourseName, CreateCourseNameDto>().ReverseMap();
            #endregion 

            #region CoCurricularActivity  Mappings 
            CreateMap<CoCurricularActivityDto, CoCurricularActivity>().ReverseMap()
             .ForMember(d => d.CoCurricularActivityType, o => o.MapFrom(s => s.CoCurricularActivityType.CoCurricularActivityName));

            CreateMap<CoCurricularActivity, CreateCoCurricularActivityDto>().ReverseMap();
            #endregion

            #region CoCurricularActivityType  Mappings 
            CreateMap<CoCurricularActivityType, CoCurricularActivityTypeDto>().ReverseMap();
            CreateMap<CoCurricularActivityType, CreateCoCurricularActivityTypeDto>().ReverseMap();
            #endregion

            #region CodeValues  Mappings 
            CreateMap<CodeValueDto, CodeValue>().ReverseMap()
              .ForMember(d => d.CodeValueType, o => o.MapFrom(s => s.CodeValueType.Type));

            CreateMap<CodeValue, CreateCodeValueDto>().ReverseMap();
            #endregion

            #region CodeValueType  Mappings 
            CreateMap<CodeValueType, CodeValueTypeDto>().ReverseMap();
            CreateMap<CodeValueType, CreateCodeValueTypeDto>().ReverseMap();
            #endregion

            #region Country  Mappings 
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            #endregion
            #region CountryGroup  Mappings 
            CreateMap<CountryGroup, CountryGroupDto>().ReverseMap();
            CreateMap<CountryGroup, CreateCountryGroupDto>().ReverseMap();
            #endregion

            #region CurrencyName  Mappings 
            CreateMap<CurrencyName, CurrencyNameDto>().ReverseMap();
            CreateMap<CurrencyName, CreateCurrencyNameDto>().ReverseMap();
            #endregion

            #region CoursePlan Mappings      
            CreateMap<CoursePlanDto, CoursePlanCreate>().ReverseMap()
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName));
            CreateMap<CoursePlanCreate, CreateCoursePlanDto>().ReverseMap();
            #endregion

            #region CourseTask Mapping    
            CreateMap<CourseTaskDto, CourseTask>().ReverseMap()
                .ForMember(d => d.SchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.SubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName));
            CreateMap<CourseTask, CreateCourseTaskDto>().ReverseMap();
            #endregion

            #region CourseModule Mappings      
            CreateMap<CourseModuleDto, CourseModule>().ReverseMap()
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName));

            CreateMap<CourseModule, CreateCourseModuleDto>().ReverseMap();
            #endregion

            #region CourseSection Mappings      
            CreateMap<CourseSectionDto, CourseSection>().ReverseMap()
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
 
                .ForMember(d => d.BnaCurriculumType, o => o.MapFrom(s => s.BnaCurriculumType.CurriculumType ))
 
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName));

            CreateMap<CourseSection, CreateCourseSectionDto>().ReverseMap();
            #endregion

            #region CourseTypes Mapping    
            CreateMap<CourseType, CourseTypeDto>().ReverseMap();
            CreateMap<CourseType, CreateCourseTypeDto>().ReverseMap();
            #endregion

            #region CourseWeeks Mapping    
            CreateMap<CourseWeekAllDto, CourseWeek>().ReverseMap()
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course));
            CreateMap<CourseWeek, CreateCourseWeekDto>().ReverseMap();
            #endregion

            #region Complexion Mappings
            CreateMap<Complexion, ComplexionDto>().ReverseMap();
            CreateMap<Complexion, CreateComplexionDto>().ReverseMap();
            #endregion

            #region CourseGradingEntry Mappings
            CreateMap<CourseGradingEntryDto, CourseGradingEntry>().ReverseMap()
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.Assessment, o => o.MapFrom(s => s.Assessment.Name));
            CreateMap<CourseGradingEntry, CreateCourseGradingEntryDto>().ReverseMap();
            #endregion

            #region CourseDurations Mappings  
            CreateMap<CourseDurationDto, CourseDuration>().ReverseMap()
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.CountryName))
                .ForMember(d => d.FiscalYear, o => o.MapFrom(s => s.FiscalYear.FiscalYearName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.CourseSyllabus, o => o.MapFrom(s => s.CourseName.CourseSyllabus))
                .ForMember(d => d.CourseType, o => o.MapFrom(s => s.CourseType.CourseTypeName))
                .ForMember(d => d.OrganizationName, o => o.MapFrom(s => s.OrganizationName.Name));

          

            CreateMap<CourseDuration, CreateCourseDurationDto>().ReverseMap();
            //CreateMap<CourseDuration, UpdateNbcdCourseDurationDto>().ReverseMap();
            #endregion

            #region CourseInstructors Mappings  
            CreateMap<CourseInstructorDto, CourseInstructor>()
                .ForPath(d => d.CourseName.Course, o => o.MapFrom(s => s.CourseName));
            CreateMap<CourseInstructor, CourseInstructorDto>()
                  .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.BnaSubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.CourseModule, o => o.MapFrom(s => s.CourseModule.ModuleName))
                .ForMember(d => d.BNASemester, o => o.MapFrom(s => s.BnaSemester.SemesterName))
                .ForMember(d => d.MarkType, o => o.MapFrom(s => s.MarkType.ShortName))
                .ForMember(d => d.Trainee, o => o.MapFrom(s => (s.Trainee.Pno +"_" + s.Trainee.Name)))
                .ForMember(d => d.TraineeName, o => o.MapFrom(s => (s.Trainee.Name)))
                .ForMember(d => d.TraineeRank, o => o.MapFrom(s => s.Trainee.Rank.Position))
                .ForMember(d => d.SaylorRank, o => o.MapFrom(s => s.Trainee.SaylorRank.Name))
                .ForMember(d => d.TraineeStatusId, o => o.MapFrom(s => s.Trainee.TraineeStatusId));

            CreateMap<CourseInstructor, CreateCourseInstructorDto>(); //eta create er dto na vaiya?
            CreateMap<CourseInstructor, ModifiedCreateCourseInstructorDto>().ReverseMap();

            #endregion

            #region CourseNomenees Mappings  
            CreateMap<CourseNomeneeDto, CourseNomenee>()
                .ForPath(d => d.CourseName.Course, o => o.MapFrom(s => s.CourseName));
            CreateMap<CourseNomenee, CourseNomeneeDto>()
                  .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.BnaSubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.CourseModule, o => o.MapFrom(s => s.CourseModule.ModuleName))
                .ForMember(d => d.BNASemester, o => o.MapFrom(s => s.BnaSemester.SemesterName))
                .ForMember(d => d.MarkType, o => o.MapFrom(s => s.MarkType.ShortName))
                .ForMember(d => d.Trainee, o => o.MapFrom(s => (s.Trainee.Pno + "_" + s.Trainee.Name)))
                .ForMember(d => d.TraineeName, o => o.MapFrom(s => (s.Trainee.Name)))
                .ForMember(d => d.TraineeRank, o => o.MapFrom(s => s.Trainee.Rank.Position))
                .ForMember(d => d.SaylorRank, o => o.MapFrom(s => s.Trainee.SaylorRank.Name))
                .ForMember(d => d.TraineeStatusId, o => o.MapFrom(s => s.Trainee.TraineeStatusId));

            CreateMap<CourseNomenee, CreateCourseNomeneeDto>(); //eta create er dto na vaiya?
            CreateMap<CourseNomenee, ModifiedCreateCourseNomeneeDto>().ReverseMap();

            #endregion


            #region CourseBudgetAllocation Mappings
            CreateMap<CourseBudgetAllocationDto, CourseBudgetAllocation>().ReverseMap()
             .ForMember(d => d.TraineeName, o => o.MapFrom(s => s.Trainee.Name))
             .ForMember(d => d.BudgetCode, o => o.MapFrom(s => s.BudgetCode.BudgetCodes))
             .ForMember(d => d.PaymentType, o => o.MapFrom(s => s.PaymentType.PaymentTypeName));

            CreateMap<CourseBudgetAllocation, CreateCourseBudgetAllocationDto>().ReverseMap();
            #endregion

            #region CovidVaccine Mappings 
            CreateMap<CovidVaccineDto, CovidVaccine>().ReverseMap();
             //.ForMember(d => d.RelationType, o => o.MapFrom(s => s.RelationType.RelationTypeName))
             //.ForMember(d => d.TraineeName, o => o.MapFrom(s => s.Trainee.Name))
             //.ForMember(d => d.TraineePNo, o => o.MapFrom(s => s.Trainee.Pno))
             //.ForMember(d => d.RankPosition, o => o.MapFrom(s => s.Trainee.Rank.Position));
            CreateMap<CovidVaccine, CreateCovidVaccineDto>().ReverseMap();
            #endregion


            //Lattar D 

            #region DefenseType Mappings 
            CreateMap<DefenseType, DefenseTypeDto>().ReverseMap();
            CreateMap<DefenseType, CreateDefenseTypeDto>().ReverseMap();
            #endregion

            #region District Mappings
            CreateMap<DistrictDto, District>().ReverseMap()
              .ForMember(d => d.Division, o => o.MapFrom(s => s.Division.DivisionName));
            CreateMap<District, CreateDistrictDto>().ReverseMap();
            #endregion

            #region Division Mappings
            CreateMap<Division, DivisionDto>().ReverseMap();
            CreateMap<Division, CreateDivisionDto>().ReverseMap();
            #endregion

            #region Document Mappings
            CreateMap<DocumentDto, Document>().ReverseMap()
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.InterServiceCourseDocType, o => o.MapFrom(s => s.InterServiceCourseDocType.Name))
                .ForMember(d => d.DocumentUpload, o => o.MapFrom<InterServiceDocumentUrlResolver>());

            CreateMap<Document, CreateDocumentDto>().ReverseMap();
            #endregion



            #region DocumentTypes  Mappings  
            CreateMap<DocumentType, DocumentTypeDto>().ReverseMap();
            CreateMap<DocumentType, CreateDocumentTypeDto>().ReverseMap();
            #endregion

            #region InterServiceCourseDocType  Mappings  
            CreateMap<InterServiceCourseDocType, InterServiceCourseDocTypeDto>().ReverseMap();
            CreateMap<InterServiceCourseDocType, CreateInterServiceCourseDocTypeDto>().ReverseMap();
            #endregion

            #region InterServiceCourseReport  Mappings  
            CreateMap<InterServiceCourseReportDto,InterServiceCourseReport>().ReverseMap()
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.Doc, o => o.MapFrom<InterServiceReportUrlResolver>());

            CreateMap<InterServiceCourseReport, CreateInterServiceCourseReportDto>().ReverseMap();
            #endregion 

            #region DownloadRight Mappings  
            CreateMap<DownloadRight, DownloadRightDto>().ReverseMap();
            CreateMap<DownloadRight, CreateDownloadRightDto>().ReverseMap();
            #endregion

            //Lattar E

            #region EducationalInstitutions Mappings   
            CreateMap<EducationalInstitutionDto, EducationalInstitution>().ReverseMap()
             .ForMember(d => d.District, o => o.MapFrom(s => s.District.DistrictName))
             .ForMember(d => d.Thana, o => o.MapFrom(s => s.Thana.ThanaName));

            CreateMap<EducationalInstitution, CreateEducationalInstitutionDto>().ReverseMap();
            #endregion

            #region TraineeAssessmentMarks Mappings   
            CreateMap<TraineeAssessmentMarkDto, TraineeAssessmentMark>().ReverseMap()
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.Trainee, o => o.MapFrom(s => s.Trainee.Pno +" "+s.Trainee.Name))
                .ForMember(d => d.TraineeAssessmentCreate, o => o.MapFrom(s => s.TraineeAssessmentCreate.AssessmentName));

            CreateMap<TraineeAssessmentMark, CreateTraineeAssessmentMarkDto>().ReverseMap();
            #endregion

            #region TraineeAssessmentCreates Mappings   
            CreateMap<TraineeAssessmentCreateDto, TraineeAssessmentCreate>().ReverseMap()
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseDuration.CourseName.Course));
            CreateMap<TraineeAssessmentCreate, CreateTraineeAssessmentCreateDto>().ReverseMap();
            #endregion

            #region TraineeAssissmentGroups Mappings   
            CreateMap<TraineeAssissmentGroupDto, TraineeAssissmentGroup>().ReverseMap()
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.Trainee, o => o.MapFrom(s => s.Trainee.Name + " (P No/ONo " + s.Trainee.Pno +")"))
                .ForMember(d => d.TraineeRank, o => o.MapFrom(s => s.Trainee.Rank.Position))
                .ForMember(d => d.SailorRank, o => o.MapFrom(s => s.Trainee.SaylorRank.Name))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseDuration.CourseName.Course));
            CreateMap<TraineeAssissmentGroup, CreateTraineeAssissmentGroupDto>().ReverseMap();
            #endregion

            #region EducationalQualification Mapping    
            CreateMap<EducationalQualificationDto, EducationalQualification>().ReverseMap()
              .ForMember(d => d.ExamType, o => o.MapFrom(s => s.ExamType.ExamTypeName))
              .ForMember(d => d.Board, o => o.MapFrom(s => s.Board.BoardName))
              .ForMember(d => d.Group, o => o.MapFrom(s => s.Group.GroupName));

            CreateMap<EducationalQualification, CreateEducationalQualificationDto>().ReverseMap();
            #endregion 

            #region Election  Mappings 
            CreateMap<ElectionDto, Election>().ReverseMap()
              .ForMember(d => d.Elected, o => o.MapFrom(s => s.Elected.ElectedType));

            CreateMap<Election, CreateElectionDto>().ReverseMap();
            #endregion

            #region Electeds  Mappings 
            CreateMap<Elected, ElectedDto>().ReverseMap();
            CreateMap<Elected, CreateElectedDto>().ReverseMap();
            #endregion 

            #region EmploymentBeforeJoinBna  Mappings 
            CreateMap<EmploymentBeforeJoinBna, EmploymentBeforeJoinBnaDto>().ReverseMap();
            CreateMap<EmploymentBeforeJoinBna, CreateEmploymentBeforeJoinBnaDto>().ReverseMap();
            #endregion

            #region Event  Mappings 
            CreateMap<EventDto, Event>().ReverseMap()
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.ShortName))
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle));

            CreateMap<Event, CreateEventDto>().ReverseMap();
            #endregion

            #region ExamAttemptType Mappings 
            CreateMap<ExamAttemptType, ExamAttemptTypeDto>().ReverseMap();
            CreateMap<ExamAttemptType, CreateExamAttemptTypeDto>().ReverseMap();
            #endregion

            #region ExamCenter Mappings 
            CreateMap<ExamCenter, ExamCenterDto>().ReverseMap();
            CreateMap<ExamCenter, CreateExamCenterDto>().ReverseMap();
            #endregion

            #region ExamCenterSelection Mappings 
            CreateMap<ExamCenterSelectionDto,ExamCenterSelection>().ReverseMap()
                .ForMember(d => d.ExamCenter, o => o.MapFrom(s => s.ExamCenter.ExamCenterName));

            CreateMap<ExamCenterSelection, CreateExamCenterSelectionDto>().ReverseMap();
            #endregion

            #region ExamMarkRemarks Mappings 
            CreateMap<ExamMarkRemarks, ExamMarkRemarkDto>().ReverseMap();
            CreateMap<ExamMarkRemarks, CreateExamMarkRemarkDto>().ReverseMap();
            #endregion

            #region ExamType Mappings 
            CreateMap<ExamType, ExamTypeDto>().ReverseMap();
            CreateMap<ExamType, CreateExamTypeDto>().ReverseMap();
            #endregion

            #region ExamPeriodTypes  Mappings  
            CreateMap<ExamPeriodType, ExamPeriodTypeDto>().ReverseMap();
            CreateMap<ExamPeriodType, CreateExamPeriodTypeDto>().ReverseMap();
            #endregion


            //Lattar F

            

            #region FamilyNomination Mappings 
            CreateMap<FamilyNominationDto, FamilyNomination>().ReverseMap()
                .ForMember(d => d.RelationType, o => o.MapFrom(s => s.RelationType.RelationTypeId.ToString()));
            CreateMap<FamilyNomination, CreateFamilyNominationDto>().ReverseMap();
            #endregion

            #region Favorites  Mappings  
            CreateMap<FavoritesDto, Favorites>().ReverseMap()
                .ForMember(d => d.FavoritesTypeName, o => o.MapFrom(s => s.FavoritesType.FavoritesTypeName));
            CreateMap<Favorites, CreateFavoritesDto>().ReverseMap();
            #endregion

            #region FailureStatus Mappings 
            CreateMap<FailureStatus, FailureStatusDto>().ReverseMap();
            CreateMap<FailureStatus, CreateFailureStatusDto>().ReverseMap();
            #endregion

            #region FamilyInfo Mappings 
            CreateMap<FamilyInfoDto, FamilyInfo>().ReverseMap()
                .ForMember(d => d.RelationType, o => o.MapFrom(s => s.RelationType.RelationTypeName))
                .ForMember(d => d.TraineeName, o => o.MapFrom(s => s.Trainee.Name))
                .ForMember(d => d.TraineePNo, o => o.MapFrom(s => s.Trainee.Pno))
                .ForMember(d => d.RankPosition, o => o.MapFrom(s => s.Trainee.Rank.Position));
            CreateMap<FamilyInfo, CreateFamilyInfoDto>().ReverseMap();
            #endregion

            #region FamilyNomination Mappings 
            CreateMap<FamilyNomination, FamilyNominationDto>().ReverseMap();

            CreateMap<FamilyNomination, CreateFamilyNominationDto>().ReverseMap();
            #endregion

            #region FavoritesType  Mappings 
            CreateMap<FavoritesType, FavoritesTypeDto>().ReverseMap();
            CreateMap<FavoritesType, CreateFavoritesTypeDto>().ReverseMap();
            #endregion

            #region Features Mapping    
            CreateMap<FeatureDto, Feature>().ReverseMap()
             .ForMember(d => d.ModuleName, o => o.MapFrom(s => s.Module.Title));

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            #endregion

            #region FiscalYear Mappings 
            CreateMap<FiscalYear, FiscalYearDto>().ReverseMap();
            CreateMap<FiscalYear, CreateFiscalYearDto>().ReverseMap();
            #endregion

            #region ForeignCourseOtherDoc Mappings 
            CreateMap<ForeignCourseOtherDocDto, ForeignCourseOtherDoc>().ReverseMap()
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseDuration.CourseName.Course));
            CreateMap<ForeignCourseOtherDoc, CreateForeignCourseOtherDocDto>().ReverseMap();
            #endregion

            #region ForeignCourseGOInfo Mappings 
            CreateMap<ForeignCourseGOInfoDto, ForeignCourseGOInfo>().ReverseMap()
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseDuration.CourseName.Course))
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.DurationFrom, o => o.MapFrom(s => s.CourseDuration.DurationFrom))
                .ForMember(d => d.DurationTo, o => o.MapFrom(s => s.CourseDuration.DurationTo))
                .ForMember(d => d.FileUpload, o => o.MapFrom<FileUploadUrlResolver>());
            CreateMap<ForeignCourseGOInfo, CreateForeignCourseGOInfoDto>().ReverseMap();
            #endregion

            #region ForceType Mapping    
            CreateMap<ForceType, ForceTypeDto>().ReverseMap();
            CreateMap<ForceType, CreateForceTypeDto>().ReverseMap();
            #endregion 
            
            #region ForeignCourseDocType  Mappings  
            CreateMap<ForeignCourseDocType, ForeignCourseDocTypeDto>().ReverseMap();
            CreateMap<ForeignCourseDocType, CreateForeignCourseDocTypeDto>().ReverseMap();
            #endregion

            #region ForeignCourseOthersDocument  Mappings  

            CreateMap<ForeignCourseOthersDocumentDto, ForeignCourseOthersDocument>().ReverseMap()
              .ForMember(d => d.ForeignCourseDocType, o => o.MapFrom(s => s.ForeignCourseDocType.Name))
              .ForMember(d => d.FileUpload, o => o.MapFrom<OtherDocumentUploadUrlResolver>());
            CreateMap<ForeignCourseOthersDocument, CreateForeignCourseOthersDocumentDto>().ReverseMap();

            //CreateMap<ForeignCourseOthersDocument, ForeignCourseOthersDocumentDto>().ReverseMap();
            //CreateMap<ForeignCourseOthersDocument, CreateForeignCourseOthersDocumentDto>().ReverseMap();
            #endregion

            //Lattar G

            #region Games  Mappings 
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<Game, CreateGameDto>().ReverseMap();
            #endregion

            #region GameSport  Mappings 
            CreateMap<GameSportDto, GameSport>().ReverseMap()
              .ForMember(d => d.Game, o => o.MapFrom(s => s.Game.GameName));
            CreateMap<GameSport, CreateGameSportDto>().ReverseMap();
            #endregion

            #region Gender Mappings 
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Gender, CreateGenderDto>().ReverseMap();
            #endregion

            #region GrandFather Mapping                
            CreateMap<GrandFatherDto, GrandFather>().ReverseMap()
              .ForMember(d => d.GrandFatherType, o => o.MapFrom(s => s.GrandFatherType.GrandfatherTypeName))
              .ForMember(d => d.Occupation, o => o.MapFrom(s => s.Occupation.OccupationName))
              .ForMember(d => d.Nationality, o => o.MapFrom(s => s.Nationality.NationalityName))
              .ForMember(d => d.DeadStatusValue, o => o.MapFrom(s => s.DeadStatusNavigation.TypeValue));
            CreateMap<GrandFather, CreateGrandFatherDto>().ReverseMap();
            #endregion

            #region GrandFatherType Mappings 
            CreateMap<GrandFatherType, GrandFatherTypeDto>().ReverseMap();
            CreateMap<GrandFatherType, CreateGrandFatherTypeDto>().ReverseMap();
            #endregion
             
            #region Groups  Mappings 
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<Group, CreateGroupDto>().ReverseMap();
            #endregion

            #region GuestSpeakerQuationGroup Mappings
            CreateMap<GuestSpeakerQuationGroupDto, GuestSpeakerQuationGroup>().ReverseMap()
                .ForMember(d => d.SchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.SubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.TraineeName, o => o.MapFrom(s => s.Trainee.Name))
                .ForMember(d => d.TraineePno, o => o.MapFrom(s => s.Trainee.Pno))
                .ForMember(d => d.TraineeRank, o => o.MapFrom(s => s.Trainee.Rank.Position))
                .ForMember(d => d.GuestSpeakerQuestionName, o => o.MapFrom(s => s.GuestSpeakerQuestionName.Name));
          // CreateMap<GuestSpeakerQuationGroup, CreateGuestSpeakerQuationGroupDto>().ReverseMap();
            #endregion

            //Lattar H

            #region HairColor Mappings 
            CreateMap<HairColor, HairColorDto>().ReverseMap();
            CreateMap<HairColor, CreateHairColorDto>().ReverseMap();
            #endregion

            #region Height Mappings 
            CreateMap<Height, HeightDto>().ReverseMap();
            CreateMap<Height, CreateHeightDto>().ReverseMap();
            #endregion

            //Lattar I


            #region InstallmentPaidDetail Mappings 

            CreateMap<InstallmentPaidDetail,InstallmentPaidDetailDto > ().ReverseMap();
            CreateMap<InstallmentPaidDetail, CreateInstallmentPaidDetailDto>().ReverseMap();
            #endregion

             
            #region InterServiceMark Mapping    
            CreateMap<InterServiceMarkDto, InterServiceMark>().ReverseMap()
                .ForMember(d => d.OrganizationName, o => o.MapFrom(s => s.OrganizationName.Name))
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseName.Course))
                .ForMember(d => d.TraineeName, o => o.MapFrom(s => s.Trainee.Name))
                .ForMember(d => d.TraineePNo, o => o.MapFrom(s => s.Trainee.Pno))
                .ForMember(d => d.RankPosition, o => o.MapFrom(s => s.Trainee.Rank.Position))
                .ForMember(d => d.Doc, o => o.MapFrom<InterServiceMarkDocUrlResolver>());


            CreateMap<InterServiceMark, CreateInterServiceMarkDto>().ReverseMap();
            #endregion


            #region IndividualNotice Mappings    
            CreateMap<IndividualNoticeDto, IndividualNotice>().ReverseMap();
            CreateMap<IndividualNotice, CreateIndividualNoticeDto>().ReverseMap();

            CreateMap<IndividualNotice, CreateIndividualNoticeListDto>().ReverseMap();
            #endregion

            #region IndividualBulletin Mappings    
            CreateMap<IndividualBulletinDto, IndividualBulletin>().ReverseMap();
            CreateMap<IndividualBulletin, CreateIndividualBulletinDto>().ReverseMap();

            CreateMap<IndividualBulletin, CreateIndividualBulletinListDto>().ReverseMap();
            #endregion
             
            #region Instructor assignments Mappings
            CreateMap<InstructorAssignment, InstructorAssignmentDto>().ReverseMap();
            CreateMap<InstructorAssignment, CreateInstructorAssignmentDto>().ReverseMap();
            #endregion

            //Lattar J

            #region JoiningReasons  Mappings  
            CreateMap<JoiningReasonDto, JoiningReason>().ReverseMap()
                 .ForMember(d => d.ReasonTypeName, o => o.MapFrom(s => s.ReasonType.ReasonTypeName));
            CreateMap<JoiningReason, CreateJoiningReasonDto>().ReverseMap();
            #endregion

            //Lattar K

            #region KindOfSubjects Mapping    
            CreateMap<KindOfSubject, KindOfSubjectDto>().ReverseMap();
            CreateMap<KindOfSubject, CreateKindOfSubjectDto>().ReverseMap();
            #endregion

            //Lattar L

            #region Languages  Mappings 
            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageDto>().ReverseMap();
            #endregion

            //Lattar M

            #region MaritalStatus Mappings 
            CreateMap<MaritalStatus, MaritalStatusDto>().ReverseMap();
            CreateMap<MaritalStatus, CreateMaritalStatusDto>().ReverseMap();
            #endregion

            #region MarkType Mappings 
            CreateMap<MarkType, MarkTypeDto>().ReverseMap();
            CreateMap<MarkType, CreateMarkTypeDto>().ReverseMap();
            #endregion

            #region MembershipTypes  Mappings 
            CreateMap<MemberShipType, MembershipTypeDto>().ReverseMap();
            CreateMap<MemberShipType, CreateMembershipTypeDto>().ReverseMap();
            #endregion

            #region MigrationDocument Mappings 
            CreateMap<MigrationDocumentDto,MigrationDocument>().ReverseMap()
                .ForMember(d => d.RelationType, o => o.MapFrom(s => s.RelationType.RelationTypeName));
            CreateMap<MigrationDocument, CreateMigrationDocumentDto>().ReverseMap();
            #endregion

            #region Modules Mapping    
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Module, ModuleFeatureDto>().ReverseMap();
            
            CreateMap<Module, CreateModuleDto>().ReverseMap();
            #endregion
             
            //Lattar N

            #region Notice Mappings
            CreateMap<NoticeDto, Notice>().ReverseMap()
           .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.ShortName +"-"+ s.CourseDuration.CourseTitle))
           .ForMember(d => d.CourseTitle, o => o.MapFrom(s => s.CourseDuration.CourseTitle));
            CreateMap<Notice, CreateNoticeDto>().ReverseMap();

          //  CreateMap<Attendance, CreateAttendanceListDto>().ReverseMap();
            #endregion



            #region Nationality Mappings
            CreateMap<Nationality, NationalityDto>().ReverseMap();
            CreateMap<Nationality, CreateNationalityDto>().ReverseMap();
            #endregion

            #region NewAtempt Mappings
            CreateMap<NewAtempt, NewAtemptDto>().ReverseMap();
            CreateMap<NewAtempt, CreateNewAtemptDto>().ReverseMap();
            #endregion

            #region NewEntryEvaluation Mappings
            CreateMap<NewEntryEvaluationDto, NewEntryEvaluation>().ReverseMap()
                .ForMember(d => d.TraineeName, o => o.MapFrom(s => s.Trainee.Name))
                .ForMember(d => d.TraineePNo, o => o.MapFrom(s => s.Trainee.Pno))
                .ForMember(d => d.RankPosition, o => o.MapFrom(s => s.Trainee.Rank.Position))
                .ForMember(d => d.CourseWeek, o => o.MapFrom(s => s.CourseWeek.WeekName));
            CreateMap<NewEntryEvaluation, CreateNewEntryEvaluationDto>().ReverseMap();
            #endregion

            //Lattar O

            #region Occupation Mappings 
            CreateMap<Occupation, OccupationDto>().ReverseMap();
            CreateMap<Occupation, CreateOccupationDto>().ReverseMap();
            #endregion

            #region OrganizationName Mappings 
            CreateMap<OrganizationNameDto,OrganizationName >().ReverseMap()
                .ForMember(d => d.ForceType, o => o.MapFrom(s => s.ForceType.ForceTypeName));
            CreateMap<OrganizationName, CreateOrganizationNameDto>().ReverseMap();
            #endregion

            //Lattar P

            #region ParentRelative Mapping    
            CreateMap<ParentRelativeDto, ParentRelative>().ReverseMap()
              .ForMember(d => d.RelationType, o => o.MapFrom(s => s.RelationType.RelationTypeName))
              .ForMember(d => d.MaritalStatus, o => o.MapFrom(s => s.MaritalStatus.MaritalStatusName))
              .ForMember(d => d.Nationality, o => o.MapFrom(s => s.Nationality.NationalityName))
              .ForMember(d => d.Religion, o => o.MapFrom(s => s.Religion.ReligionName))
              .ForMember(d => d.Caste, o => o.MapFrom(s => s.Caste.CastName))
              .ForMember(d => d.Occupation, o => o.MapFrom(s => s.Occupation.OccupationName))
              .ForMember(d => d.Gender, o => o.MapFrom(s => s.Gender.GenderName))
              .ForMember(d => d.PreviousOccupation, o => o.MapFrom(s => s.PreviousOccupation.OccupationName))
              .ForMember(d => d.Division, o => o.MapFrom(s => s.Division.DivisionName))
              .ForMember(d => d.District, o => o.MapFrom(s => s.District.DistrictName))
              .ForMember(d => d.Thana, o => o.MapFrom(s => s.Thana.ThanaName))
              .ForMember(d => d.DefenseType, o => o.MapFrom(s => s.DefenseType.DefenseTypeName))
              .ForMember(d => d.Rank, o => o.MapFrom(s => s.Rank.RankName))

              

              .ForMember(d => d.SecondNationality, o => o.MapFrom(s => s.SecondNationality.NationalityName))
              .ForMember(d => d.DeadStatusValue, o => o.MapFrom(s => s.DeadStatusNavigation.TypeValue));



            CreateMap<ParentRelative, CreateParentRelativeDto>().ReverseMap();
            #endregion 

            #region PaymentDetail Mappings 
            CreateMap<PaymentDetail, PaymentDetailDto>().ReverseMap();
            CreateMap<PaymentDetail, CreatePaymentDetailDto>().ReverseMap();
            #endregion

            #region PresentBillet Mappings 
            CreateMap<PresentBillet, PresentBilletDto>().ReverseMap();
            CreateMap<PresentBillet, CreatePresentBilletDto>().ReverseMap();
            #endregion
             
            #region PaymentType Mappings 
            CreateMap<PaymentType, PaymentTypeDto>().ReverseMap();
            CreateMap<PaymentType, CreatePaymentTypeDto>().ReverseMap();
            #endregion

            //Lattar Q

            #region Question  Mappings 
            CreateMap<QuestionDto, Question>().ReverseMap()
            .ForMember(d => d.QuestionType, o => o.MapFrom(s => s.QuestionType.Question));
            CreateMap<Question, CreateQuestionDto>().ReverseMap();
            #endregion

            #region QuestionType  Mappings 
            CreateMap<QuestionType, QuestionTypeDto>().ReverseMap();
            CreateMap<QuestionType, CreateQuestionTypeDto>().ReverseMap();
            #endregion

            //Lattar R

            #region Rank Mappings
            CreateMap<Rank, RankDto>().ReverseMap();
            CreateMap<Rank, CreateRankDto>().ReverseMap();
            #endregion

            #region Religion Mappings
            CreateMap<Religion, ReligionDto>().ReverseMap();
            CreateMap<Religion, CreateReligionDto>().ReverseMap();
            #endregion

            #region RelationType Mappings 
            CreateMap<RelationType, RelationTypeDto>().ReverseMap();
            CreateMap<RelationType, CreateRelationTypeDto>().ReverseMap();
            #endregion

            #region ReasonType  Mappings 
            CreateMap<ReasonType, ReasonTypeDto>().ReverseMap();
            CreateMap<ReasonType, CreateReasonTypeDto>().ReverseMap();
            #endregion

            #region ResultStatus Mappings  
            CreateMap<ResultStatus, ResultStatusDto>().ReverseMap();
            CreateMap<ResultStatus, CreateResultStatusDto>().ReverseMap();
            #endregion

            #region ReadingMaterial Mappings    
            CreateMap<ReadingMaterialDto, ReadingMaterial>().ReverseMap()
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.DocumentType, o => o.MapFrom(s => s.DocumentType.DocumentTypeName))
                .ForMember(d => d.DownloadRight, o => o.MapFrom(s => s.DownloadRight.DownloadRightName))
                .ForMember(d => d.ShowRight, o => o.MapFrom(s => s.ShowRight.SchoolName))
                .ForMember(d => d.ReadingMaterialTitle, o => o.MapFrom(s => s.ReadingMaterialTitle.Title))
                .ForMember(d => d.DocumentIcon, o => o.MapFrom(s => s.DocumentType.IconName))
                .ForMember(d => d.DocumentLink, o => o.MapFrom<FileUrlResolver>());

            CreateMap<ReadingMaterial, CreateReadingMaterialDto>().ReverseMap();
            #endregion


            #region RoutineSoftCopyUpload Mappings    
            CreateMap<RoutineSoftCopyUploadDto, RoutineSoftCopyUpload>().ReverseMap()
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseDuration.CourseName.Course))
                .ForMember(d => d.DocumentLink, o => o.MapFrom<RoutineSoftCopyUploadResolver>());

            CreateMap<RoutineSoftCopyUpload, CreateRoutineSoftCopyUploadDto>().ReverseMap();
            #endregion

            #region ReadingMaterialTitle Mappings    
            CreateMap<ReadingMaterialTitle, ReadingMaterialTitleDto>().ReverseMap();
            CreateMap<ReadingMaterialTitle, CreateReadingMaterialTitleDto>().ReverseMap();
          
            #endregion 

            #region RoleFeature Mappings 
            CreateMap<RoleFeature, RoleFeatureDto>().ReverseMap();
            CreateMap<RoleFeature, CreateRoleFeatureDto>().ReverseMap();
            #endregion

            #region RoutineNote  Mappings 
            CreateMap<RoutineNoteDto,RoutineNote>().ReverseMap()
                .ForMember(d => d.BnaSubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course +"_"+s.CourseDuration.CourseTitle))
                .ForMember(d => d.ClassRoutine, o => o.MapFrom(s => s.BnaSubjectName.SubjectName +"-"+s.ClassRoutine.ClassPeriod.PeriodName));
            CreateMap<RoutineNote, CreateRoutineNoteDto>().ReverseMap();
            #endregion

            //Lattar S


            #region SocialMediaTypes  Mappings 
            CreateMap<SocialMediaType, SocialMediaTypeDto>().ReverseMap();
            CreateMap<SocialMediaType, CreateSocialMediaTypeDto>().ReverseMap();
            #endregion

            #region SocialMedias  Mappings  
            CreateMap<SocialMediaDto, SocialMedia>().ReverseMap()
                .ForMember(d => d.SocialMediaTypeName, o => o.MapFrom(s => s.SocialMediaType.SocialMediaTypeName));
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            #endregion

            #region StepRelation Mapping    
            CreateMap<StepRelation, StepRelationDto>().ReverseMap();
            CreateMap<StepRelation, CreateStepRelationDto>().ReverseMap();
            #endregion

            #region SubjectCategorys Mapping    
            CreateMap<SubjectCategory, SubjectCategoryDto>().ReverseMap();
            CreateMap<SubjectCategory, CreateSubjectCategoryDto>().ReverseMap();
            #endregion 

            #region SubjectMark Mapping    
            CreateMap<SubjectMarkDto,SubjectMark>().ReverseMap()
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.BnaSubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.CourseModule, o => o.MapFrom(s => s.CourseModule.ModuleName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.BnaSemester, o => o.MapFrom(s => s.BnaSemester.SemesterName))
                .ForMember(d => d.MarkCategory, o => o.MapFrom(s => s.MarkCategory.CategoryName))
                .ForMember(d => d.SubjectCurriculumName, o => o.MapFrom(s => s.BnaSubjectName.BnaSubjectCurriculum.SubjectCurriculumName))
                .ForMember(d => d.MarkType, o => o.MapFrom(s => s.MarkType.TypeName));

            CreateMap<SubjectMark, CreateSubjectMarkDto>().ReverseMap();
            #endregion

            #region SubjectTypes Mapping    
            CreateMap<SubjectType, SubjectTypeDto>().ReverseMap();
            CreateMap<SubjectType, CreateSubjectTypeDto>().ReverseMap();
            #endregion

            #region SubjectClassifications Mapping     
            CreateMap<SubjectClassification, SubjectClassificationDto>().ReverseMap();
            CreateMap<SubjectClassification, CreateSubjectClassificationDto>().ReverseMap();
            #endregion

            #region SwimmingDiving  Mappings 
            CreateMap<SwimmingDriving, SwimmingDrivingDto>().ReverseMap();
            CreateMap<SwimmingDriving, CreateSwimmingDrivingDto>().ReverseMap();
            #endregion

            #region SwimmingDrivingLevel Mapping     
            CreateMap<SwimmingDrivingLevelDto, SwimmingDrivingLevel>().ReverseMap();
            CreateMap<SwimmingDrivingLevel, CreateSwimmingDrivingLevelDto>().ReverseMap();
            #endregion


            //Lattar T

            #region TdecActionStatus Mappings
            CreateMap<TdecActionStatus, TdecActionStatusDto>().ReverseMap();
            CreateMap<TdecActionStatus, CreateTdecActionStatusDto>().ReverseMap();
            #endregion

            #region TdecGroupResult Mappings
            CreateMap<TdecGroupResult, TdecGroupResultDto>().ReverseMap();
            CreateMap<TdecGroupResult, CreateTdecGroupResultDto>().ReverseMap();
            #endregion

            #region TdecQuestionName Mappings
            CreateMap<TdecQuestionName, TdecQuestionNameDto>().ReverseMap();
            CreateMap<TdecQuestionName, CreateTdecQuestionNameDto>().ReverseMap();
            #endregion

            #region TdecQuationGroup Mappings
            CreateMap<TdecQuationGroupDto, TdecQuationGroup >().ReverseMap()
                .ForMember(d => d.SchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.SubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.TraineeName, o => o.MapFrom(s => s.Trainee.Name))
                .ForMember(d => d.TraineePno, o => o.MapFrom(s => s.Trainee.Pno))
                .ForMember(d => d.TraineeRank, o => o.MapFrom(s => s.Trainee.Rank.Position))
                .ForMember(d => d.TdecQuestionName, o => o.MapFrom(s => s.TdecQuestionName.Name));
            CreateMap<TdecQuationGroup, CreateTdecQuationGroupDto>().ReverseMap();
            #endregion

            #region Thana Mappings
            CreateMap<ThanaDto, Thana>().ReverseMap()
              .ForMember(d => d.District, o => o.MapFrom(s => s.District.DistrictName));
            CreateMap<Thana, CreateThanaDto>().ReverseMap();
            #endregion

            #region SaylorRank Mappings
            CreateMap<SaylorRank, SaylorRankDto>().ReverseMap();
            CreateMap<SaylorRank, CreateSaylorRankDto>().ReverseMap();
            #endregion

            #region SaylorBranch Mappings
            CreateMap<SaylorBranch, SaylorBranchDto>().ReverseMap();
            CreateMap<SaylorBranch, CreateSaylorBranchDto>().ReverseMap();
            #endregion

            #region SaylorSubBranch Mappings
            CreateMap<SaylorSubBranchDto, SaylorSubBranch>().ReverseMap()
                .ForMember(d => d.SaylorBranch, o => o.MapFrom(s => s.SaylorBranch.Name));
            CreateMap<SaylorSubBranch, CreateSaylorSubBranchDto>().ReverseMap();
            #endregion

            #region TraineeBIODataGeneralInfo Mapping    
            CreateMap<TraineeBioDataGeneralInfoDto, TraineeBioDataGeneralInfo>().ReverseMap()
                .ForMember(d => d.BnaBatch, o => o.MapFrom(s => s.BnaBatch.BatchName))
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.CountryName))
                .ForMember(d => d.TraineeStatus, o => o.MapFrom(s => s.TraineeStatus.Name))
                .ForMember(d => d.Rank, o => o.MapFrom(s => s.Rank.Position))
                .ForMember(d => d.SaylorRank, o => o.MapFrom(s => s.SaylorRank.Name))
                .ForMember(d => d.SaylorBranch, o => o.MapFrom(s => s.SaylorBranch.Name))
                .ForMember(d => d.SaylorSubBranch, o => o.MapFrom(s => s.SaylorSubBranch.Name))

                .ForMember(d => d.BnaPhotoUrl, o => o.MapFrom<PhotoUrlResolver>());

            


            CreateMap<TraineeBioDataGeneralInfo, CreateTraineeBioDataGeneralInfoDto>().ReverseMap()
                .ForMember(d => d.JoiningDate, o => o.MapFrom(s => Convert.ToDateTime(s.JoiningDate)))
                .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => Convert.ToDateTime(s.DateOfBirth)));
            #endregion

            #region TraineeBIODataOther Mapping    
            CreateMap<TraineeBioDataOtherDto, TraineeBioDataOther>().ReverseMap()
              .ForMember(d => d.BloodGroup, o => o.MapFrom(s => s.BloodGroup.BloodGroupName))
              .ForMember(d => d.BnaClassSectionSelection, o => o.MapFrom(s => s.BnaClassSectionSelection.SectionName))


              .ForMember(d => d.BnaCurriculumType, o => o.MapFrom(s => s.BnaCurriculumType.CurriculumType))


              .ForMember(d => d.BnaInstructorType, o => o.MapFrom(s => s.BnaInstructorType.InstructorTypeName))
              .ForMember(d => d.BnaPromotionStatus, o => o.MapFrom(s => s.BnaPromotionStatus.PromotionStatusName))
              .ForMember(d => d.BnaSemester, o => o.MapFrom(s => s.BnaSemester.SemesterName))
              .ForMember(d => d.BnaServiceType, o => o.MapFrom(s => s.BnaServiceType.ServiceName))
              .ForMember(d => d.Branch, o => o.MapFrom(s => s.Branch.BranchName))
              .ForMember(d => d.Caste, o => o.MapFrom(s => s.Caste.CastName))
              .ForMember(d => d.ColorOfEye, o => o.MapFrom(s => s.ColorOfEye.ColorOfEyeName))
              .ForMember(d => d.Complexion, o => o.MapFrom(s => s.Complexion.ComplexionName))
              .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
              .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.CountryName))
              .ForMember(d => d.FailureStatus, o => o.MapFrom(s => s.FailureStatus.FailureStatusName))
              .ForMember(d => d.Height, o => o.MapFrom(s => s.Height.HeightName))
              .ForMember(d => d.MaritalStatus, o => o.MapFrom(s => s.MaritalStatus.MaritalStatusName))
              .ForMember(d => d.PresentBillet, o => o.MapFrom(s => s.PresentBillet.PresentBilletName))
              .ForMember(d => d.Religion, o => o.MapFrom(s => s.Religion.ReligionName))
            //  .ForMember(d => d.TraineeBIODataGeneralInfo, o => o.MapFrom(s => s.TraineeBIODataGeneralInfo.nam))
              .ForMember(d => d.UtofficerCategory, o => o.MapFrom(s => s.UtofficerCategory.UtofficerCategoryName))
              .ForMember(d => d.UtofficerType, o => o.MapFrom(s => s.UtofficerType.UtofficerTypeName));
              //.ForMember(d => d.Weight, o => o.MapFrom(s => s.Weight.WeightName));

            CreateMap<TraineeBioDataOther, CreateTraineeBioDataOtherDto>().ReverseMap();
            #endregion 

            #region TraineeCourseStatus Mappings 
            CreateMap<TraineeCourseStatus, TraineeCourseStatusDto>().ReverseMap();
            CreateMap<TraineeCourseStatus, CreateTraineeCourseStatusDto>().ReverseMap();
            #endregion

            #region TraineeLanguages Mappings    
            CreateMap<TraineeLanguageDto, TraineeLanguage>().ReverseMap()
                .ForMember(d => d.LanguageName, o => o.MapFrom(s => s.Language.LanguageName));
            CreateMap<TraineeLanguage, CreateTraineeLanguageDto>().ReverseMap();
            #endregion

            #region TraineeMembership  Mappings 
            CreateMap<TraineeMembershipDto, TraineeMembership>().ReverseMap()
                .ForMember(d => d.MembershipType, o => o.MapFrom(s => s.MembershipType.MembershipTypeName));

            CreateMap<TraineeMembership, CreateTraineeMembershipDto>().ReverseMap();
            #endregion


            #region TraineeNomination Mappings      
            CreateMap<TraineeNominationDto, TraineeNomination>().ReverseMap()
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                 .ForMember(d => d.SchoolName, o => o.MapFrom(s => s.CourseDuration.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.TraineeCourseStatus, o => o.MapFrom(s => s.TraineeCourseStatus.TraineeCourseStatusName))
                .ForMember(d => d.WithdrawnDoc, o => o.MapFrom(s => s.WithdrawnDoc.WithdrawnDocName))
                .ForMember(d => d.TraineeName, o => o.MapFrom(s => s.Trainee.Name))
                .ForMember(d => d.NewAtempt, o => o.MapFrom(s => s.NewAtempt.Name))
                .ForMember(d => d.TraineePNo, o => o.MapFrom(s => s.Trainee.Pno))
                .ForMember(d => d.TraineeStatusId, o => o.MapFrom(s => s.Trainee.TraineeStatusId))
                .ForMember(d => d.TraineeDOB, o => o.MapFrom(s => s.Trainee.DateOfBirth))
                .ForMember(d => d.TraineeJoiningDate, o => o.MapFrom(s => s.Trainee.JoiningDate))
                .ForMember(d => d.Trainee, o => o.MapFrom(s => (s.Trainee.Pno + "_" + s.Trainee.Name)))
                .ForMember(d=>d.RankName,o=>o.MapFrom(s=>s.Trainee.Rank.RankName))
                .ForMember(d => d.RankPosition, o => o.MapFrom(s => s.Trainee.Rank.Position))
                .ForMember(d => d.SaylorRank, o => o.MapFrom(s => s.Trainee.SaylorRank.Name))
                .ForMember(d => d.saylorBranch, o => o.MapFrom(s => s.Trainee.SaylorBranch.Name))
                .ForMember(d => d.ExamCenter, o => o.MapFrom(s => s.ExamCenter.ExamCenterName))
                .ForMember(d => d.WithdrawnType, o => o.MapFrom(s => s.WithdrawnType.Name));
           
            CreateMap<CourseDuration, TraineeNominationDto>().ReverseMap();

            CreateMap<TraineeNominationDto, ForeignCourseOtherDoc>().ReverseMap()
                .ForMember(d => d.RankPosition, o => o.MapFrom(s => s.Trainee.Rank.Position));

            //CreateMap<ForeignCourseOtherDoc, TraineeNominationDto>().ReverseMap();

            CreateMap<TraineeNomination, TraineeNominationTestDto>().ReverseMap();
            CreateMap<TraineeNomination, CreateTraineeNominationDto>().ReverseMap();
            #endregion


            #region TraineeSectionSelection Mapping    
            CreateMap<TraineeSectionSelectionDto,TraineeSectionSelection>().ReverseMap()
                .ForMember(d => d.BnaBatch, o => o.MapFrom(s => s.BnaBatch.BatchName))
                .ForMember(d => d.BnaClassSectionSelection, o => o.MapFrom(s => s.BnaClassSectionSelection.SectionName))
                .ForMember(d => d.PreviewsSection, o => o.MapFrom(s => s.PreviewsSection.SectionName))
                .ForMember(d => d.BnaSemester, o => o.MapFrom(s => s.BnaSemester.SemesterName));
            CreateMap<TraineeSectionSelection, CreateTraineeSectionSelectionDto>().ReverseMap();
            #endregion

            #region TraineePicture Mapping    
            CreateMap<TraineePicture, TraineePictureDto>().ReverseMap();
            CreateMap<TraineePicture, CreateTraineePictureDto>().ReverseMap();
            #endregion


            #region TraineeVisitedAboard  Mappings 
            CreateMap<TraineeVisitedAboardDto, TraineeVisitedAboard>().ReverseMap()
                .ForMember(d => d.Country, o => o.MapFrom(s => s.Country.CountryName));
            CreateMap<TraineeVisitedAboard, CreateTraineeVisitedAboardDto>().ReverseMap();
            #endregion

            #region TrainingObjective Mappings 
            CreateMap<TrainingObjectiveDto, TrainingObjective>().ReverseMap()
                .ForMember(d => d.SchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.SubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.CourseTask, o => o.MapFrom(s => s.CourseTask.TaskDetail));
            CreateMap<TrainingObjective, CreateTrainingObjectiveDto>().ReverseMap();
            #endregion

            #region TrainingSyllabus Mappings 
            CreateMap<TrainingSyllabusDto, TrainingSyllabus>().ReverseMap()
                .ForMember(d => d.SchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                .ForMember(d => d.SubjectName, o => o.MapFrom(s => s.BnaSubjectName.SubjectName))
                .ForMember(d => d.CourseTask, o => o.MapFrom(s => s.CourseTask.TaskDetail))
                .ForMember(d => d.TrainingObjective, o => o.MapFrom(s => s.TrainingObjective.TrainingObjectDetail));
            CreateMap<TrainingSyllabus, CreateTrainingSyllabusDto>().ReverseMap();
            #endregion

            #region UserManual Mappings
            CreateMap<UserManualDto, UserManual>().ReverseMap()
                .ForMember(d => d.Doc, o => o.MapFrom<UserManualUrlResolver>());
            CreateMap<UserManual, CreateUserManualDto>().ReverseMap();
            #endregion

            #region Trainee assignments submit Mappings
            CreateMap<TraineeAssignmentSubmitDto,TraineeAssignmentSubmit>().ReverseMap()
                .ForMember(d => d.ImageUpload, o => o.MapFrom<AssignmentSubmitFileUploadUrlResolver>());

            CreateMap<TraineeAssignmentSubmit, CreateTraineeAssignmentSubmitDto>().ReverseMap();
            #endregion

            //Lattar U

            #region UTOfficerType Mappings
            CreateMap<UtofficerType, UtofficerTypeDto>().ReverseMap();
            CreateMap<UtofficerType, CreateUtofficerTypeDto>().ReverseMap();
            #endregion

            #region WeekName Mappings
            CreateMap<WeekName, WeekNameDto>().ReverseMap();
            CreateMap<WeekName, CreateWeekNameDto>().ReverseMap();
            #endregion

            #region UTOfficerCategory Mappings
            CreateMap<UtofficerCategory, UtofficerCategoryDto>().ReverseMap();
            CreateMap<UtofficerCategory, CreateUtofficerCategoryDto>().ReverseMap();
            #endregion

            //Lattar W

            #region Weight Mappings 
            CreateMap<Weight, WeightDto>().ReverseMap();
            CreateMap<Weight, CreateWeightDto>().ReverseMap();
            #endregion

            #region WithdrawnDoc Mappings 
            CreateMap<WithdrawnDoc, WithdrawnDocDto>().ReverseMap();
            CreateMap<WithdrawnDoc, CreateWithdrawnDocDto>().ReverseMap();
            #endregion

            #region WithdrawnType Mappings 
            CreateMap<WithdrawnType, WithdrawnTypeDto>().ReverseMap();
            CreateMap<WithdrawnType, CreateWithdrawnTypeDto>().ReverseMap();
            #endregion

            #region GuestSpeakerQuestionName Mappings 
            CreateMap<GuestSpeakerQuestionName, GuestSpeakerQuestionNameDto>().ReverseMap();
            CreateMap<GuestSpeakerQuestionName, CreateGuestSpeakerQuestionNameDto>().ReverseMap();
            #endregion

            #region GuestSpeakerActionStatus Mappings 
            CreateMap<GuestSpeakerActionStatus, GuestSpeakerActionStatusDto>().ReverseMap();
            CreateMap<GuestSpeakerActionStatus, CreateGuestSpeakerActionStatusDto>().ReverseMap();
            #endregion

            #region RecordOfService Mappings 
            CreateMap<RecordOfService, RecordOfServiceDto>().ReverseMap();
            CreateMap<RecordOfService, CreateRecordOfServiceDto>().ReverseMap();
            #endregion

            #region MilitaryTraining Mappings 
            CreateMap<MilitaryTraining, MilitaryTrainingDto>().ReverseMap();
            CreateMap<MilitaryTraining, CreateMilitaryTrainingDto>().ReverseMap();
            #endregion

            #region ForeignTrainingCourseReport  Mappings  
            CreateMap<ForeignTrainingCourseReportDto, ForeignTrainingCourseReport>().ReverseMap()
                .ForMember(d => d.CourseDuration, o => o.MapFrom(s => s.CourseDuration.CourseTitle))
                .ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                  .ForMember(d => d.TraineeName, o => o.MapFrom(s => s.Trainee.Name))
                .ForMember(d => d.TraineePNo, o => o.MapFrom(s => s.Trainee.Pno))
                .ForMember(d => d.RankName, o => o.MapFrom(s => s.Trainee.Rank.RankName))
                .ForMember(d => d.RankPosition, o => o.MapFrom(s => s.Trainee.Rank.Position))
                .ForMember(d => d.Doc, o => o.MapFrom<ForeignTrainingReportUrlResolver>());
            CreateMap<ForeignTrainingCourseReport, CreateForeignTrainingCourseReportDto>().ReverseMap();
            #endregion

            #region FinancialSanction Mappings 
            CreateMap<FinancialSanction, FinancialSanctionDto>().ReverseMap();
            CreateMap<FinancialSanction, CreateFinancialSanctionDto>().ReverseMap();
            #endregion

            #region Department Mappings
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            #endregion

            #region MarkCategory Mappings
            CreateMap<MarkCategory, MarkCategoryDto>().ReverseMap();
            CreateMap<MarkCategory, CreateMarkCategoryDto>().ReverseMap();
            #endregion

            #region BnaClassPeriod Mappings
            CreateMap<BnaClassPeriod, BnaClassPeriodDto>().ReverseMap();
            CreateMap<BnaClassPeriod, CreateBnaClassPeriodDto>().ReverseMap();
            #endregion


            #region BnaClassAttendance Mappings
            CreateMap<Domain.BnaClassAttendance, BnaClassAttendanceDto>().ReverseMap();
            CreateMap<Domain.BnaClassAttendance, CreateBnaClassAttendanceDto>().ReverseMap();
            #endregion


            #region CourseTerm Mappings
            CreateMap<Domain.CourseTerm, CourseTermDto>().ReverseMap();
            CreateMap<Domain.CourseTerm, CreateCourseTermDto>().ReverseMap();
            #endregion

            #region CourseLevel Mappings
            CreateMap<Domain.CourseLevel, CourseLevelDto>().ReverseMap();
            CreateMap<Domain.CourseLevel, CreateCourseLevelDto>().ReverseMap();
            #endregion


            CreateMap<UniversityCourseResult, UniversityCourseResultDto>().ReverseMap();

            CreateMap<UniversityCourseResult, CreateUniversityCourseResultDto>().ReverseMap();



        }
    }

}
