using SchoolManagement.Domain;
using Microsoft.EntityFrameworkCore;


namespace SchoolManagement.Persistence
{
    public class SchoolManagementDbContext : AuditableDbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AccountType>(entity =>
            {

            });

            modelBuilder.Entity<AdminAuthority>(entity =>
            {

            });

            modelBuilder.Entity<Allowance>(entity =>
            {
                entity.HasOne(d => d.AllowanceCategory)
                   .WithMany(p => p.Allowances)
                   .HasForeignKey(d => d.AllowanceCategoryId)
                   .HasConstraintName("FK_Allowance_AllowanceCategory");

                entity.HasOne(d => d.FromRank)
                    .WithMany(p => p.AllowanceFromRanks)
                    .HasForeignKey(d => d.FromRankId)
                    .HasConstraintName("FK_Allowance_Rank");

                entity.HasOne(d => d.ToRank)
                     .WithMany(p => p.AllowanceToRanks)
                     .HasForeignKey(d => d.ToRankId)
                     .HasConstraintName("FK_Allowance_Rank1");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Allowances)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Allowance_Country");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.Allowances)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_Allowance_CourseName");

            });

            modelBuilder.Entity<AllowanceCategory>(entity =>
            {
                entity.HasOne(d => d.FromRank)
                    .WithMany(p => p.AllowanceCategoryFromRanks)
                    .HasForeignKey(d => d.FromRankId)
                    .HasConstraintName("FK_AllowanceCategory_Rank");

                entity.HasOne(d => d.ToRank)
                     .WithMany(p => p.AllowanceCategoryToRanks)
                     .HasForeignKey(d => d.ToRankId)
                     .HasConstraintName("FK_AllowanceCategory_Rank1");

                entity.HasOne(d => d.CountryGroup)
                     .WithMany(p => p.AllowanceCategories)
                     .HasForeignKey(d => d.CountryGroupId)
                     .HasConstraintName("FK_AllowanceCategory_CountryGroup");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.AllowanceCategories)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_AllowanceCategory_Country");

                entity.HasOne(d => d.CurrencyName)
                    .WithMany(p => p.AllowanceCategories)
                    .HasForeignKey(d => d.CurrencyNameId)
                    .HasConstraintName("FK_AllowanceCategory_CurrencyName");

                entity.HasOne(d => d.AllowancePercentage)
                    .WithMany(p => p.AllowanceCategories)
                    .HasForeignKey(d => d.AllowancePercentageId)
                    .HasConstraintName("FK_AllowanceCategory_AllowancePercentage");

            });
            modelBuilder.Entity<AllowancePercentage>(entity =>
            {

            });

            modelBuilder.Entity<Assessment>(entity =>
            {

            });

            modelBuilder.Entity<AssignmentMarkEntry>(entity =>
            {
                entity.HasOne(d => d.TraineeAssignmentSubmit)
                     .WithMany(p => p.AssignmentMarkEntries)
                     .HasForeignKey(d => d.TraineeAssignmentSubmitId)
                     .HasConstraintName("FK_AssignmentMarkEntry_TraineeAssignmentSubmit");

            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                     .WithMany(p => p.Attendances)
                     .HasForeignKey(d => d.BaseSchoolNameId)
                     .HasConstraintName("FK_Attendance_BaseSchoolName");

                entity.HasOne(d => d.BnaAttendanceRemarks)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.BnaAttendanceRemarksId)
                    .HasConstraintName("FK_Attendance_BnaAttendanceRemarks");

                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.BnaBatchId)
                    .HasConstraintName("FK_Attendance_BnaBatch");

                entity.HasOne(d => d.BnaExamSchedule)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.BnaExamScheduleId)
                    .HasConstraintName("FK_Attendance_BnaExamSchedule");

                entity.HasOne(d => d.BnaSemesterDuration)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.BnaSemesterDurationId)
                    .HasConstraintName("FK_Attendance_BnaSemesterDuration");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_Attendance_BnaSemester");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_Attendance_BnaSubjectName");

                entity.HasOne(d => d.ClassPeriod)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.ClassPeriodId)
                    .HasConstraintName("FK_Attendance_ClassPeriod");

                entity.HasOne(d => d.ClassRoutine)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.ClassRoutineId)
                    .HasConstraintName("FK_Attendance_ClassRoutine");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_Attendance_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_Attendance_CourseName");

                entity.HasOne(d => d.ExamType)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.ExamTypeId)
                    .HasConstraintName("FK_Attendance_ExamType");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_Attendance_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<CovidVaccine>(entity =>
            {
                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.CovidVaccines)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_CovidVaccine_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<BaseName>(entity =>
            {
                entity.HasOne(d => d.AdminAuthority)
                    .WithMany(p => p.BaseNames)
                    .HasForeignKey(d => d.AdminAuthorityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaseName_AdminAuthority");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.BaseNames)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_BaseName_District");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.BaseNames)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaseName_Division");

                entity.HasOne(d => d.ForceType)
                    .WithMany(p => p.BaseNames)
                    .HasForeignKey(d => d.ForceTypeId)
                    .HasConstraintName("FK_BaseName_ForceType");
            });

            modelBuilder.Entity<BaseSchoolName>(entity =>
            {

                entity.HasOne(d => d.BaseName)
                    .WithMany(p => p.BaseSchoolNames)
                    .HasForeignKey(d => d.BaseNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaseSchoolName_BaseName");

            });

            modelBuilder.Entity<BloodGroup>(entity =>
            {

            });

            modelBuilder.Entity<BnaAttendancePeriod>(entity =>
            {

            });

            modelBuilder.Entity<BnaAttendanceRemarks>(entity =>
            {

            });

            modelBuilder.Entity<BnaBatch>(entity =>
            {

            });

            

            modelBuilder.Entity<BnaClassSchedule>(entity =>
            {

                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.BnaClassSchedules)
                    .HasForeignKey(d => d.BnaBatchId)
                    .HasConstraintName("FK_BnaClassSchedule_BnaBatch");

                entity.HasOne(d => d.BnaClassScheduleStatus)
                    .WithMany(p => p.BnaClassSchedules)
                    .HasForeignKey(d => d.BnaClassScheduleStatusId)
                    .HasConstraintName("FK_BnaClassSchedule_BnaClassScheduleStatus");

                entity.HasOne(d => d.BnaClassSectionSelection)
                    .WithMany(p => p.BnaClassSchedules)
                    .HasForeignKey(d => d.BnaClassSectionSelectionId)
                    .HasConstraintName("FK_BnaClassSchedule_BnaClassSectionSelection");

                entity.HasOne(d => d.BnaSemesterDuration)
                    .WithMany(p => p.BnaClassSchedules)
                    .HasForeignKey(d => d.BnaSemesterDurationId)
                    .HasConstraintName("FK_BnaClassSchedule_BnaSemesterDuration");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.BnaClassSchedules)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_BnaClassSchedule_BnaSemester");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.BnaClassSchedules)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_BnaClassSchedule_BnaSubjectName");

                entity.HasOne(d => d.ClassPeriod)
                    .WithMany(p => p.BnaClassSchedules)
                    .HasForeignKey(d => d.ClassPeriodId)
                    .HasConstraintName("FK_BnaClassSchedule_ClassPeriod");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.BnaClassSchedules)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_BnaClassSchedule_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<BnaClassScheduleStatus>(entity =>
            {

            });

            modelBuilder.Entity<BnaClassSectionSelection>(entity =>
            {

            });

            modelBuilder.Entity<BnaClassTest>(entity =>
            {

                entity.HasOne(d => d.BnaClassTestType)
                    .WithMany(p => p.BnaClassTests)
                    .HasForeignKey(d => d.BnaClassTestTypeId)
                    .HasConstraintName("FK_BnaClassTest_BnaClassTestType");

                entity.HasOne(d => d.BnaSemesterDuration)
                    .WithMany(p => p.BnaClassTests)
                    .HasForeignKey(d => d.BnaSemesterDurationId)
                    .HasConstraintName("FK_BnaClassTest_BnaSemesterDuration");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.BnaClassTests)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_BnaClassTest_BnaSemester");

                entity.HasOne(d => d.BnaSubjectCurriculum)
                    .WithMany(p => p.BnaClassTests)
                    .HasForeignKey(d => d.BnaSubjectCurriculumId)
                    .HasConstraintName("FK_BnaClassTest_BnaSubjectCurriculum");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.BnaClassTests)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_BnaClassTest_BnaSubjectName");

                entity.HasOne(d => d.SubjectCategory)
                    .WithMany(p => p.BnaClassTests)
                    .HasForeignKey(d => d.SubjectCategoryId)
                    .HasConstraintName("FK_BnaClassTest_SubjectCategory");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.BnaClassTests)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_BnaClassTest_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<BnaClassTestType>(entity =>
            {

            });

            modelBuilder.Entity<BnaCurriculumType>(entity =>
            {

            });

            modelBuilder.Entity<BnaCurriculumUpdate>(entity =>
            {
                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.BnaCurriculumUpdates)
                    .HasForeignKey(d => d.BnaBatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BnaCurriculumUpdate_BnaBatch");

                entity.HasOne(d => d.BnaCurriculumType)
                    .WithMany(p => p.BnaCurriculumUpdates)
                    .HasForeignKey(d => d.BnaCurriculumTypeId)
                    .HasConstraintName("FK_BnaCurriculumUpdate_BnaCurriculumType");

                entity.HasOne(d => d.BnaSemesterDuration)
                    .WithMany(p => p.BnaCurriculumUpdates)
                    .HasForeignKey(d => d.BnaSemesterDurationId)
                    .HasConstraintName("FK_BnaCurriculumUpdate_BnaSemesterDuration");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.BnaCurriculumUpdates)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BnaCurriculumUpdate_BnaSemester");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.BnaCurriculumUpdates)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_BnaCurriculumUpdate_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<BnaExamAttendance>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_BnaExamAttendance_BaseSchoolName");

                entity.HasOne(d => d.BnaAttendanceRemarks)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.BnaAttendanceRemarksId)
                    .HasConstraintName("FK_BnaExamAttendance_BnaAttendanceRemarks");

                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.BnaBatchId)
                    .HasConstraintName("FK_BnaExamAttendance_BnaBatch");

                entity.HasOne(d => d.BnaExamSchedule)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.BnaExamScheduleId)
                    .HasConstraintName("FK_BnaExamAttendance_BnaExamSchedule");

                entity.HasOne(d => d.BnaSemesterDuration)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.BnaSemesterDurationId)
                    .HasConstraintName("FK_BnaExamAttendance_BnaSemesterDuration");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_BnaExamAttendance_BnaSemester");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_BnaExamAttendance_BnaSubjectName");

                entity.HasOne(d => d.ClassPeriod)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.ClassPeriodId)
                    .HasConstraintName("FK_BnaExamAttendance_ClassPeriod");

                entity.HasOne(d => d.ClassRoutine)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.ClassRoutineId)
                    .HasConstraintName("FK_BnaExamAttendance_ClassRoutine");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_BnaExamAttendance_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_BnaExamAttendance_CourseName");

                entity.HasOne(d => d.ExamType)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.ExamTypeId)
                    .HasConstraintName("FK_BnaExamAttendance_ExamType");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.BnaExamAttendances)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_BnaExamAttendance_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<BnaExamInstructorAssign>(entity =>
            {
                entity.ToTable("BnaExamInstructorAssign");

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.BnaExamInstructorAssigns)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_BnaExamInstructorAssign_BaseSchoolName");

                entity.HasOne(d => d.BnaInstructorType)
                    .WithMany(p => p.BnaExamInstructorAssigns)
                    .HasForeignKey(d => d.BnaInstructorTypeId)
                    .HasConstraintName("FK_BnaExamInstructorAssign_BnaInstructorType");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.BnaExamInstructorAssigns)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_BnaExamInstructorAssign_BnaSubjectName");

                entity.HasOne(d => d.ClassRoutine)
                    .WithMany(p => p.BnaExamInstructorAssigns)
                    .HasForeignKey(d => d.ClassRoutineId)
                    .HasConstraintName("FK_BnaExamInstructorAssign_ClassRoutine");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.BnaExamInstructorAssigns)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_BnaExamInstructorAssign_CourseDuration");

                entity.HasOne(d => d.CourseModule)
                    .WithMany(p => p.BnaExamInstructorAssigns)
                    .HasForeignKey(d => d.CourseModuleId)
                    .HasConstraintName("FK_BnaExamInstructorAssign_CourseModule");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.BnaExamInstructorAssigns)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_BnaExamInstructorAssign_CourseName");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.BnaExamInstructorAssigns)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_BnaExamInstructorAssign_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<BnaExamMark>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_BnaExamMark_BaseSchoolName");

                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.BnaBatchId)
                    .HasConstraintName("FK_BnaExamMark_BnaBatch");

                entity.HasOne(d => d.BnaCurriculumType)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.BnaCurriculumTypeId)
                    .HasConstraintName("FK_BnaExamMark_BnaCurriculumType");

                entity.HasOne(d => d.BnaExamSchedule)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.BnaExamScheduleId)
                    .HasConstraintName("FK_BnaExamMark_BnaExamSchedule");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_BnaExamMark_BnaSemester");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_BnaExamMark_BnaSubjectName");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_BnaExamMark_Branch");

                entity.HasOne(d => d.ClassRoutine)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.ClassRoutineId)
                    .HasConstraintName("FK_BnaExamMark_ClassRoutine");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_BnaExamMark_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_BnaExamMark_CourseName");

                entity.HasOne(d => d.ExamMarkRemarks)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.ExamMarkRemarksId)
                    .HasConstraintName("FK_BnaExamMark_ExamMarkRemarks");

                entity.HasOne(d => d.SubjectMark)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.SubjectMarkId)
                    .HasConstraintName("FK_BnaExamMark_SubjectMark");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_BnaExamMark_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.BnaExamMarks)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_BnaExamMark_TraineeNomination");
            });


            modelBuilder.Entity<BnaExamRoutineLog>(entity =>
            {
                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.BnaExamRoutineLogs)
                    .HasForeignKey(d => d.BnaBatchId)
                    .HasConstraintName("FK_BnaExamRoutineLog_BnaBatch");

                entity.HasOne(d => d.BnaClassSectionSelection)
                    .WithMany(p => p.BnaExamRoutineLogs)
                    .HasForeignKey(d => d.BnaClassSectionSelectionId)
                    .HasConstraintName("FK_BnaExamRoutineLog_BnaClassSectionSelection");

                entity.HasOne(d => d.BnaExamInstructorAssign)
                    .WithMany(p => p.BnaExamRoutineLogs)
                    .HasForeignKey(d => d.BnaExamInstructorAssignId)
                    .HasConstraintName("FK_BnaExamRoutineLog_BnaExamInstructorAssign");

                entity.HasOne(d => d.BnaExamSchedule)
                    .WithMany(p => p.BnaExamRoutineLogs)
                    .HasForeignKey(d => d.BnaExamScheduleId)
                    .HasConstraintName("FK_BnaExamRoutineLog_BnaExamSchedule");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.BnaExamRoutineLogs)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_BnaExamRoutineLog_BnaSemester");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.BnaExamRoutineLogs)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_BnaExamRoutineLog_BnaSubjectName");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.BnaExamRoutineLogs)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_BnaExamRoutineLog_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<BnaExamSchedule>(entity =>
            {
                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.BnaExamSchedules)
                    .HasForeignKey(d => d.BnaBatchId)
                    .HasConstraintName("FK_BnaExamSchedule_BnaBatch");

                entity.HasOne(d => d.BnaSemesterDuration)
                    .WithMany(p => p.BnaExamSchedules)
                    .HasForeignKey(d => d.BnaSemesterDurationId)
                    .HasConstraintName("FK_BnaExamSchedule_BnaSemesterDuration");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.BnaExamSchedules)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_BnaExamSchedule_BnaSemester");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.BnaExamSchedules)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_BnaExamSchedule_BnaSubjectName");

                entity.HasOne(d => d.ExamType)
                    .WithMany(p => p.BnaExamSchedules)
                    .HasForeignKey(d => d.ExamTypeId)
                    .HasConstraintName("FK_BnaExamSchedule_ExamType");
            });

            modelBuilder.Entity<BnaInstructorType>(entity =>
            {

            });

            modelBuilder.Entity<BnaPromotionLog>(entity =>
            {
                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.BnaPromotionLogs)
                    .HasForeignKey(d => d.BnaBatchId)
                    .HasConstraintName("FK_BnaPromotionLog_BnaBatch");

                entity.HasOne(d => d.BnaPromotionStatus)
                    .WithMany(p => p.BnaPromotionLogs)
                    .HasForeignKey(d => d.BnaPromotionStatusId)
                    .HasConstraintName("FK_BnaPromotionLog_BnaPromotionStatus");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.BnaPromotionLogs)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_BnaPromotionLog_BnaSemester");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.BnaPromotionLogs)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_BnaPromotionLog_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<BnaPromotionStatus>(entity =>
            {

            });

            modelBuilder.Entity<BnaSemester>(entity =>
            {

            });

            modelBuilder.Entity<BnaSemesterDuration>(entity =>
            {
                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.BnaSemesterDurations)
                    .HasForeignKey(d => d.BnaBatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BnaSemesterDuration_BnaBatch");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.BnaSemesterDurationBnaSemesters)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BnaSemesterDuration_BnaSemester");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.BnaSemesterDurations)
                    .HasForeignKey(d => d.CourseDurationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BnaSemesterDuration_CourseDuration");

                entity.HasOne(d => d.NextSemester)
                    .WithMany(p => p.BnaSemesterDurationNextSemesters)
                    .HasForeignKey(d => d.NextSemesterId)
                    .HasConstraintName("FK_BnaSemesterDuration_NextSemester");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.BnaSemesterDurations)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BnaSemesterDuration_Rank");

                entity.HasOne(d => d.SemesterLocationTypeNavigation)
                    .WithMany(p => p.BnaSemesterDurations)
                    .HasForeignKey(d => d.SemesterLocationType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BnaSemesterDuration_CodeValue");
            });

            modelBuilder.Entity<BnaServiceType>(entity =>
            {

            });

            modelBuilder.Entity<BnaSubjectCurriculum>(entity =>
            {

            });

            modelBuilder.Entity<BnaSubjectName>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_BnaSubjectName_BaseSchoolName");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_BnaSubjectName_BnaSemester");

                entity.HasOne(d => d.BnaSubjectCurriculum)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.BnaSubjectCurriculumId)
                    .HasConstraintName("FK_BnaSubjectName_BnaSubjectCurriculum");

                entity.HasOne(d => d.CourseModule)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.CourseModuleId)
                    .HasConstraintName("FK_BnaSubjectName_CourseModule");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_BnaSubjectName_CourseName");

                entity.HasOne(d => d.KindOfSubject)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.KindOfSubjectId)
                    .HasConstraintName("FK_BnaSubjectName_KindOfSubject");

                entity.HasOne(d => d.ResultStatus)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.ResultStatusId)
                    .HasConstraintName("FK_BnaSubjectName_CodeValue");

                entity.HasOne(d => d.CourseType)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.CourseTypeId)
                    .HasConstraintName("FK_BnaSubjectName_CourseType");

                entity.HasOne(d => d.SubjectCategory)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.SubjectCategoryId)
                    .HasConstraintName("FK_BnaSubjectName_SubjectCategory");

                entity.HasOne(d => d.SubjectClassification)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.SubjectClassificationId)
                    .HasConstraintName("FK_BnaSubjectName_SubjectClassification");

                entity.HasOne(d => d.SubjectType)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.SubjectTypeId)
                    .HasConstraintName("FK_BnaSubjectName_SubjectType");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_BnaSubjectName_Branch");

                entity.HasOne(d => d.SaylorBranch)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.SaylorBranchId)
                    .HasConstraintName("FK_BnaSubjectName_SaylorBranch");

                entity.HasOne(d => d.SaylorSubBranch)
                    .WithMany(p => p.BnaSubjectNames)
                    .HasForeignKey(d => d.SaylorSubBranchId)
                    .HasConstraintName("FK_BnaSubjectName_SaylorSubBranch");

                entity.HasOne(d => d.Department)
                   .WithMany(p => p.BnaSubjectNames)
                   .HasForeignKey(d => d.DepartmentId)
                   .HasConstraintName("FK_BnaSubjectName_Department");
            });

            modelBuilder.Entity<Board>(entity =>
            {

            });

            modelBuilder.Entity<Department>(entity =>
            {

            });

            modelBuilder.Entity<Branch>(entity =>
            {

            });


            modelBuilder.Entity<Bulletin>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.Bulletins)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_Bulletin_BaseSchoolName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.Bulletins)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_Bulletin_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.Bulletins)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_Bulletin_CourseName");
            });

            modelBuilder.Entity<BudgetAllocation>(entity =>
            {          
                entity.HasOne(d => d.BudgetCode)
                    .WithMany(p => p.BudgetAllocations)
                    .HasForeignKey(d => d.BudgetCodeId)
                    .HasConstraintName("FK_BudgetAllocation_BudgetCode");

                entity.HasOne(d => d.BudgetType)
                    .WithMany(p => p.BudgetAllocations)
                    .HasForeignKey(d => d.BudgetTypeId)
                    .HasConstraintName("FK_BudgetAllocation_BudgetType");

                entity.HasOne(d => d.FiscalYear)
                    .WithMany(p => p.BudgetAllocations)
                    .HasForeignKey(d => d.FiscalYearId)
                    .HasConstraintName("FK_BudgetAllocation_FiscalYear");
            });

            modelBuilder.Entity<BudgetType>(entity =>
            {

            });
            modelBuilder.Entity<BudgetCode>(entity =>
            {

            });

            modelBuilder.Entity<CourseBudgetAllocation>(entity =>
            {
                entity.HasOne(d => d.BudgetCode)
                    .WithMany(p => p.CourseBudgetAllocations)
                    .HasForeignKey(d => d.BudgetCodeId)
                    .HasConstraintName("FK_CourseBudgetAllocation_BudgetCode");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.CourseBudgetAllocations)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_CourseBudgetAllocation_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.CourseBudgetAllocations)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_CourseBudgetAllocation_CourseName");

                entity.HasOne(d => d.CourseType)
                    .WithMany(p => p.CourseBudgetAllocations)
                    .HasForeignKey(d => d.CourseTypeId)
                    .HasConstraintName("FK_CourseBudgetAllocation_CourseType");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.CourseBudgetAllocations)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK_CourseBudgetAllocation_PaymentType");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.CourseBudgetAllocations)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_CourseBudgetAllocation_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
               
            });


            modelBuilder.Entity<Caste>(entity =>
            {
                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.Castes)
                    .HasForeignKey(d => d.ReligionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Caste_Religion");
            });

            modelBuilder.Entity<ClassInstructorAssign>(entity =>
            {
                entity.HasOne(d => d.BnaClassSchedule)
                    .WithMany(p => p.ClassInstructorAssigns)
                    .HasForeignKey(d => d.BnaClassScheduleId)
                    .HasConstraintName("FK_ClassInstructorAssign_BnaClassSchedule");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.ClassInstructorAssigns)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_ClassInstructorAssign_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<ClassPeriod>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.ClassPeriods)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_ClassPeriod_BaseSchoolName");

                entity.HasOne(d => d.BnaClassScheduleStatus)
                    .WithMany(p => p.ClassPeriods)
                    .HasForeignKey(d => d.BnaClassScheduleStatusId)
                    .HasConstraintName("FK_ClassPeriod_BnaClassScheduleStatus");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.ClassPeriods)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_ClassPeriod_CourseName");
            });

            modelBuilder.Entity<ClassRoutine>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_ClassRoutine_BaseSchoolName");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_ClassRoutine_BnaSubjectName");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_ClassRoutine_Branch");

                entity.HasOne(d => d.ClassPeriod)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.ClassPeriodId)
                    .HasConstraintName("FK_ClassRoutine_ClassPeriod");

                entity.HasOne(d => d.ClassType)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.ClassTypeId)
                    .HasConstraintName("FK_ClassRoutine_ClassType");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_ClassRoutine_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_ClassRoutine_CourseName");

                entity.HasOne(d => d.CourseModule)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.CourseModuleId)
                    .HasConstraintName("FK_ClassRoutine_CourseModule");

                entity.HasOne(d => d.CourseWeek)
                    .WithMany(p => p.ClassRoutines)
                    .HasForeignKey(d => d.CourseWeekId)
                    .HasConstraintName("FK_ClassRoutine_CourseWeek");
            });

            modelBuilder.Entity<ClassType>(entity =>
            {

            });

            modelBuilder.Entity<CoCurricularActivity>(entity =>
            {
                entity.HasOne(d => d.CoCurricularActivityType)
                    .WithMany(p => p.CoCurricularActivities)
                    .HasForeignKey(d => d.CoCurricularActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoCurricularActivity_CoCurricularActivityType");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.CoCurricularActivities)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CoCurricularActivity_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<CoCurricularActivityType>(entity =>
            {

            });

            modelBuilder.Entity<CodeValue>(entity =>
            {
                entity.HasOne(d => d.CodeValueType)
                    .WithMany(p => p.CodeValues)
                    .HasForeignKey(d => d.CodeValueTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CodeValue_CodeValueType");
            });

            modelBuilder.Entity<CodeValueType>(entity =>
            {

            });

            modelBuilder.Entity<ColorOfEye>(entity =>
            {

            });

            modelBuilder.Entity<Complexion>(entity =>
            {

            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasOne(d => d.CountryGroup)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.CountryGroupId)
                    .HasConstraintName("FK_Country_CountryGroup");

                entity.HasOne(d => d.CurrencyName)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.CurrencyNameId)
                    .HasConstraintName("FK_Country_CurrencyName");

            });
            modelBuilder.Entity<CountryGroup>(entity =>
            {

            });

            modelBuilder.Entity<CourseDuration>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.CourseDurations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_CourseDuration_BaseSchoolName");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CourseDurations)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_CourseDuration_Country");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.CourseDurations)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_CourseDuration_CourseName");

                entity.HasOne(d => d.CourseType)
                    .WithMany(p => p.CourseDurations)
                    .HasForeignKey(d => d.CourseTypeId)
                    .HasConstraintName("FK_CourseDuration_CourseType");


                entity.HasOne(d => d.OrganizationName)
                    .WithMany(p => p.CourseDurations)
                    .HasForeignKey(d => d.OrganizationNameId)
                    .HasConstraintName("FK_CourseDuration_OrganizationName");

                //entity.HasOne(d => d.NbcdSchool)
                //  .WithMany(p => p.CourseDurationNbcdSchools)
                //  .HasForeignKey(d => d.NbcdSchoolId)
                //  .HasConstraintName("FK_CourseDuration_NbcdSchoolId");

                entity.HasOne(d => d.FiscalYear)
                    .WithMany(p => p.CourseDurations)
                    .HasForeignKey(d => d.FiscalYearId)
                    .HasConstraintName("FK_CourseDuration_FiscalYear");
            });

            modelBuilder.Entity<CourseGradingEntry>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.CourseGradingEntries)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_CourseGradingEntry_BaseSchoolName");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.CourseGradingEntries)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_CourseGradingEntry_CourseName");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.CourseGradingEntries)
                    .HasForeignKey(d => d.AssessmentId)
                    .HasConstraintName("FK_CourseGradingEntry_Assessment");

            });

            modelBuilder.Entity<CourseInstructor>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.CourseInstructors)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_CourseInstructor_BaseSchoolName");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.CourseInstructors)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_CourseInstructor_BnaSubjectName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.CourseInstructors)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_CourseInstructor_CourseDuration");

                entity.HasOne(d => d.CourseModule)
                    .WithMany(p => p.CourseInstructors)
                    .HasForeignKey(d => d.CourseModuleId)
                    .HasConstraintName("FK_CourseInstructor_CourseModule");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.CourseInstructors)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_CourseInstructor_CourseName");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.CourseInstructors)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_CourseInstructor_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.CourseInstructors)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_CourseInstructor_BnaSemester");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.CourseInstructors)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_CourseInstructor_Department");

                entity.HasOne(d => d.BnaSubjectCurriculum)
                    .WithMany(p => p.CourseInstructors)
                    .HasForeignKey(d => d.BnaSubjectCurriculumId)
                    .HasConstraintName("FK_CourseInstructor_BnaSubjectCurriculum");
            });


            modelBuilder.Entity<CourseNomenee>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.CourseNomenees)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_CourseNomenee_BaseSchoolName");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.CourseNomenees)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_TraineeNomination_courseNomenee");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.CourseNomenees)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_CourseNomenee_BnaSubjectName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.CourseNomenees)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_CourseNomenee_CourseDuration");

                entity.HasOne(d => d.CourseModule)
                    .WithMany(p => p.CourseNomenees)
                    .HasForeignKey(d => d.CourseModuleId)
                    .HasConstraintName("FK_CourseNomenee_CourseModule");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.CourseNomenees)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_CourseNomenee_CourseName");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.CourseNomenees)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_CourseNomenee_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.CourseNomenees)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_CourseNomenee_BnaSemester");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.CourseNomenees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_CourseNomenee_Department");

                entity.HasOne(d => d.BnaSubjectCurriculum)
                    .WithMany(p => p.CourseNomenees)
                    .HasForeignKey(d => d.BnaSubjectCurriculumId)
                    .HasConstraintName("FK_CourseNomenee_BnaSubjectCurriculum");
            });


            modelBuilder.Entity<CourseModule>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.CourseModules)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_CourseModule_BaseSchoolName");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.CourseModules)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_CourseModule_CourseName");
            });

            modelBuilder.Entity<CourseName>(entity =>
            {
                entity.HasOne(d => d.CourseType)
                    .WithMany(p => p.CourseNames)
                    .HasForeignKey(d => d.CourseTypeId)
                    .HasConstraintName("FK_CourseName_CourseType");
            });

            modelBuilder.Entity<CoursePlanCreate>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.CoursePlanCreates)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_CoursePlanCreate_BaseSchoolName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.CoursePlanCreates)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_CoursePlanCreate_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.CoursePlanCreates)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_CoursePlanCreate_CourseName");
            });

            modelBuilder.Entity<CourseType>(entity =>
            {
                

            });

            modelBuilder.Entity<CourseTask>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.CourseTasks)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_CourseTask_BaseSchoolName");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.CourseTasks)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_CourseTask_CourseName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.CourseTasks)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_CourseTask_CourseDuration");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.CourseTasks)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_CourseTask_BnaSubjectName");

            });
            modelBuilder.Entity<CourseWeek>(entity =>
            {                

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.CourseWeeks)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_CourseWeek_BaseSchoolName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.CourseWeeks)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_CourseWeek_CourseDuration");

                entity.HasOne(d => d.BnaSemesterDuration)
                    .WithMany(p => p.CourseWeeks)
                    .HasForeignKey(d => d.BnaSemesterDurationId)
                    .HasConstraintName("FK_CourseWeek_BnaSemesterDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.CourseWeeks)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_CourseWeek_CourseName");
            });
            modelBuilder.Entity<CurrencyName>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CurrencyNames)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_CurrencyName_Country");

            });

            modelBuilder.Entity<DefenseType>(entity =>
            {

            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_District_Division");
            });

            modelBuilder.Entity<Division>(entity =>
            {

            });


            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_Document_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_Document_CourseName");

                entity.HasOne(d => d.CourseType)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.CourseTypeId)
                    .HasConstraintName("FK_Document_CourseType");

                entity.HasOne(d => d.InterServiceCourseDocType)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.InterServiceCourseDocTypeId)
                    .HasConstraintName("FK_Document_InterServiceCourseDocType");


            });


            modelBuilder.Entity<DocumentType>(entity =>
            {

            });

            modelBuilder.Entity<InterServiceCourseDocType>(entity =>
            {

            });

            modelBuilder.Entity<InterServiceCourseReport>(entity =>
            {
                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.InterServiceCourseReports)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_InterServiceCourseReport_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.InterServiceCourseReports)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_InterServiceCourseReport_CourseName");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.InterServiceCourseReports)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_InterServiceCourseReport_TraineeBioDataGeneralInfo");

            });

            modelBuilder.Entity<DownloadRight>(entity =>
            {

            });

            modelBuilder.Entity<EducationalInstitution>(entity =>
            {
                entity.HasOne(d => d.District)
                    .WithMany(p => p.EducationalInstitutions)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationalInstitutions_District");

                entity.HasOne(d => d.Thana)
                    .WithMany(p => p.EducationalInstitutions)
                    .HasForeignKey(d => d.ThanaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationalInstitutions_Thana");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.EducationalInstitutions)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationalInstitution_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<EducationalQualification>(entity =>
            {

                entity.HasOne(d => d.Board)
                   .WithMany(p => p.EducationalQualifications)
                   .HasForeignKey(d => d.BoardId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_EducationalQualification_Boards");


                entity.HasOne(d => d.ExamType)
                    .WithMany(p => p.EducationalQualifications)
                    .HasForeignKey(d => d.ExamTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationalQualification_ExamType");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.EducationalQualifications)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationalQualification_Group");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.EducationalQualifications)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EducationalQualification_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<Elected>(entity =>
            {

            });

            modelBuilder.Entity<Election>(entity =>
            {
                entity.HasOne(d => d.Elected)
                    .WithMany(p => p.Elections)
                    .HasForeignKey(d => d.ElectedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Election_Elected");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.Elections)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Election_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<EmploymentBeforeJoinBna>(entity =>
            {
                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.EmploymentBeforeJoinBnas)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmploymentBeforeJoinBna_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_Event_BaseSchoolName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_Event_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_Event_CourseName");
            });

            modelBuilder.Entity<ExamAttemptType>(entity =>
            {

            });

            modelBuilder.Entity<ExamCenter>(entity =>
            {

            });

            modelBuilder.Entity<ExamCenterSelection>(entity =>
            {
                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.ExamCenterSelections)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamCenterSelection_TraineeNomination");

                entity.HasOne(d => d.BnaExamSchedule)
                    .WithMany(p => p.ExamCenterSelections)
                    .HasForeignKey(d => d.BnaExamScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamCenterSelection_BnaExamSchedule");

                entity.HasOne(d => d.ExamCenter)
                    .WithMany(p => p.ExamCenterSelections)
                    .HasForeignKey(d => d.ExamCenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamCenterSelection_ExamCenter");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.ExamCenterSelections)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExamCenterSelection_TraineeBioDataGeneralInfo");

            });

            modelBuilder.Entity<ExamMarkRemarks>(entity =>
            {

            });

            modelBuilder.Entity<ExamPeriodType>(entity =>
            {

            });

            modelBuilder.Entity<ExamType>(entity =>
            {

            });

            modelBuilder.Entity<FailureStatus>(entity =>
            {

            });

            modelBuilder.Entity<FinancialSanction>(entity =>
            {

            });

            modelBuilder.Entity<ForeignCourseGOInfo>(entity =>
            {
                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.ForeignCourseGOInfos)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_ForeignCourseGOInfo_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.ForeignCourseGOInfos)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_ForeignCourseGOInfo_CourseName");

            });
            modelBuilder.Entity<ForeignCourseOtherDoc>(entity =>
            {
                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.ForeignCourseOtherDocs)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_ForeignCourseOtherDoc_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.ForeignCourseOtherDocs)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_ForeignCourseOtherDoc_CourseDuration");

                entity.HasOne(d => d.FinancSanction)
                   .WithMany(p => p.ForeignCourseOtherDocs)
                   .HasForeignKey(d => d.FinancialSanctionId)
                   .HasConstraintName("FK_ForeignCourseOtherDoc_FinancialSanction");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.ForeignCourseOtherDocs)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_ForeignCourseOtherDoc_CourseName");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.ForeignCourseOtherDocs)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_ForeignCourseOtherDoc_TraineeNomination");

            });
            modelBuilder.Entity<FamilyInfo>(entity =>
            {
                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.FamilyInfos)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_FamilyInfo_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.RelationType)
                    .WithMany(p => p.FamilyInfos)
                    .HasForeignKey(d => d.RelationTypeId)
                    .HasConstraintName("FK_FamilyInfo_RelationType");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.FamilyInfos)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("FK_FamilyInfo_Religion");

                entity.HasOne(d => d.Caste)
                    .WithMany(p => p.FamilyInfos)
                    .HasForeignKey(d => d.CasteId)
                    .HasConstraintName("FK_FamilyInfo_Caste");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.FamilyInfos)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_FamilyInfo_Gender");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.FamilyInfos)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK_FamilyInfo_Division");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.FamilyInfos)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_FamilyInfo_District");

                entity.HasOne(d => d.Thana)
                    .WithMany(p => p.FamilyInfos)
                    .HasForeignKey(d => d.ThanaId)
                    .HasConstraintName("FK_FamilyInfo_Thana");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.FamilyInfos)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_FamilyInfo_Nationality");

            });

            modelBuilder.Entity<FamilyNomination>(entity =>
            {

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.FamilyNominations)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_FamilyNomination_CourseDuration");

                entity.HasOne(d => d.FundingDetail)
                    .WithMany(p => p.FamilyNominations)
                    .HasForeignKey(d => d.FundingDetailId)
                    .HasConstraintName("FK_FamilyNomination_CodeValue");

                entity.HasOne(d => d.RelationType)
                    .WithMany(p => p.FamilyNominations)
                    .HasForeignKey(d => d.RelationTypeId)
                    .HasConstraintName("FK_FamilyNomination_RelationType");

                entity.HasOne(d => d.FamilyInfo)
                    .WithMany(p => p.FamilyNominations)
                    .HasForeignKey(d => d.FamilyInfoId)
                    .HasConstraintName("FK_FamilyNomination_FamilyInfo");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.FamilyNominations)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_FamilyNomination_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.FamilyNominations)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_FamilyNomination_TraineeNomination");
            });

            modelBuilder.Entity<Favorites>(entity =>
            {
                entity.HasOne(d => d.FavoritesType)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.FavoritesTypeId)
                    .HasConstraintName("FK_Favorites_FavoritesType");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_Favorites_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<FavoritesType>(entity =>
            {

            });

            modelBuilder.Entity<FamilyNomination>(entity =>
            {
                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.FamilyNominations)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_FamilyNomination_CourseDuration");

                entity.HasOne(d => d.FundingDetail)
                    .WithMany(p => p.FamilyNominations)
                    .HasForeignKey(d => d.FundingDetailId)
                    .HasConstraintName("FK_FamilyNomination_CodeValue");

                entity.HasOne(d => d.RelationType)
                    .WithMany(p => p.FamilyNominations)
                    .HasForeignKey(d => d.RelationTypeId)
                    .HasConstraintName("FK_FamilyNomination_RelationType");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.FamilyNominations)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_FamilyNomination_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.FamilyNominations)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_FamilyNomination_TraineeNomination");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feature_Module");
            });

            modelBuilder.Entity<FiscalYear>(entity =>
            {

            });

            modelBuilder.Entity<ForceType>(entity =>
            {

            });

            modelBuilder.Entity<Game>(entity =>
            {

            });

            modelBuilder.Entity<GameSport>(entity =>
            {
                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameSports)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameSports_Game");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.GameSports)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameSport_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<Gender>(entity =>
            {

            });

            modelBuilder.Entity<GrandFather>(entity =>
            {
                entity.HasOne(d => d.DeadStatusNavigation)
                    .WithMany(p => p.GrandFathers)
                    .HasForeignKey(d => d.DeadStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrandFather_CodeValue");

                entity.HasOne(d => d.GrandFatherType)
                    .WithMany(p => p.GrandFathers)
                    .HasForeignKey(d => d.GrandFatherTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrandFather_GrandFatherType");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.GrandFathers)
                    .HasForeignKey(d => d.NationalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrandFather_Nationality");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.GrandFathers)
                    .HasForeignKey(d => d.OccupationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrandFather_Occupation");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.GrandFathers)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GrandFather_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<GrandFatherType>(entity =>
            {

            });

            modelBuilder.Entity<Group>(entity =>
            {

            });

            modelBuilder.Entity<GuestSpeakerActionStatus>(entity =>
            {

            });

            modelBuilder.Entity<GuestSpeakerGroupResult>(entity =>
            {
                //entity.HasOne(d => d.GuestSpeakerActionStatus)
                //    .WithMany(p => p.GuestSpeakerGroupResults)
                //    .HasForeignKey(d => d.GuestSpeakerActionStatusId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_GuestSpeakerGroupResult_GuestSpeakerActionStatus");

                //entity.HasOne(d => d.GuestSpeakerQuationGroup)
                //    .WithMany(p => p.GuestSpeakerGroupResults)
                //    .HasForeignKey(d => d.GuestSpeakerQuationGroupId)
                //    .HasConstraintName("FK_GuestSpeakerGroupResult_GuestSpeakerQuationGroup");

                //entity.HasOne(d => d.TraineeNomination)
                //    .WithMany(p => p.GuestSpeakerGroupResults)
                //    .HasForeignKey(d => d.TraineeNominationId)
                //    .HasConstraintName("FK_GuestSpeakerGroupResult_TraineeNomination");
            });

            modelBuilder.Entity<GuestSpeakerQuationGroup>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.GuestSpeakerQuationGroups)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_GuestSpeakerQuationGroup_BaseSchoolName");

                entity.HasOne(d => d.BnaExamInstructorAssign)
                    .WithMany(p => p.GuestSpeakerQuationGroups)
                    .HasForeignKey(d => d.BnaExamInstructorAssignId)
                    .HasConstraintName("FK_GuestSpeakerQuationGroup_BnaExamInstructorAssign");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.GuestSpeakerQuationGroups)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_GuestSpeakerQuationGroup_BnaSubjectName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.GuestSpeakerQuationGroups)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_GuestSpeakerQuationGroup_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.GuestSpeakerQuationGroups)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_GuestSpeakerQuationGroup_CourseName");

                entity.HasOne(d => d.GuestSpeakerQuestionName)
                    .WithMany(p => p.GuestSpeakerQuationGroups)
                    .HasForeignKey(d => d.GuestSpeakerQuestionNameId)
                    .HasConstraintName("FK_GuestSpeakerQuationGroup_GuestSpeakerQuestionName");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.GuestSpeakerQuationGroups)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_GuestSpeakerQuationGroup_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<GuestSpeakerQuestionName>(entity =>
            {
                //entity.HasOne(d => d.BaseSchoolName)
                //    .WithMany(p => p.GuestSpeakerQuestionNames)
                //    .HasForeignKey(d => d.BaseSchoolNameId)
                //    .HasConstraintName("FK_GuestSpeakerQuestionName_BaseSchoolName");
            });

            modelBuilder.Entity<HairColor>(entity =>
            {

            });

            modelBuilder.Entity<Height>(entity =>
            {

            });

            modelBuilder.Entity<InstallmentPaidDetail>(entity =>
            {
                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.InstallmentPaidDetails)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_InstallmentPaidDetail_CourseDuration");

               

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.InstallmentPaidDetails)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_InstallmentPaidDetail_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<InterServiceMark>(entity =>
            {
                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.InterServiceMarks)
                    .HasForeignKey(d => d.CourseDurationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InterServiceMark_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.InterServiceMarks)
                    .HasForeignKey(d => d.CourseNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InterServiceMark_CourseName");

                entity.HasOne(d => d.CourseType)
                    .WithMany(p => p.InterServiceMarks)
                    .HasForeignKey(d => d.CourseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InterServiceMark_CourseType");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.InterServiceMarks)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InterServiceMark_Country");

                entity.HasOne(d => d.OrganizationName)
                    .WithMany(p => p.InterServiceMarks)
                    .HasForeignKey(d => d.OrganizationNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InterServiceMark_OrganizationName");


                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.InterServiceMarks)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InterServiceMark_TraineeNomination");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.InterServiceMarks)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InterServiceMark_TraineeBioDataGeneralInfo");

            });

            modelBuilder.Entity<InstructorAssignment>(entity =>
            {
                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.InstructorAssignments)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_InstructorAssignment_BaseSchoolName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.InstructorAssignments)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_InstructorAssignment_CourseDuration");

                entity.HasOne(d => d.CourseInstructor)
                    .WithMany(p => p.InstructorAssignments)
                    .HasForeignKey(d => d.CourseInstructorId)
                    .HasConstraintName("FK_InstructorAssignment_CourseInstructor");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.InstructorAssignments)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_InstructorAssignment_CourseName");
            });

            modelBuilder.Entity<JoiningReason>(entity =>
            {


                entity.HasOne(d => d.ReasonType)
                    .WithMany(p => p.JoiningReasons)
                    .HasForeignKey(d => d.ReasonTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JoiningReason_ReasonType");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.JoiningReasons)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JoiningReason_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<KindOfSubject>(entity =>
            {

            });

            modelBuilder.Entity<Language>(entity =>
            {

            });

            modelBuilder.Entity<MaritalStatus>(entity =>
            {

            });

            modelBuilder.Entity<MarkType>(entity =>
            {

            });

            modelBuilder.Entity<MemberShipType>(entity =>
            {

            });

            modelBuilder.Entity<MigrationDocument>(entity =>
            {
                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.MigrationDocuments)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_MigrationDocuments_CourseDuration");

                entity.HasOne(d => d.RelationType)
                    .WithMany(p => p.MigrationDocuments)
                    .HasForeignKey(d => d.RelationTypeId)
                    .HasConstraintName("FK_MigrationDocuments_RelationType");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.MigrationDocuments)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_MigrationDocuments_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.MigrationDocuments)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_MigrationDocuments_TraineeNomination");
            });

            modelBuilder.Entity<Module>(entity =>
            {

            });

            modelBuilder.Entity<MilitaryTraining>(entity =>
            {
                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.MilitaryTrainings)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_MilitaryTraining_TraineeBioDataGeneralInfo");
            });


            modelBuilder.Entity<Nationality>(entity =>
            {

            });

            modelBuilder.Entity<NewAtempt>(entity =>
            {

            });

            modelBuilder.Entity<NewEntryEvaluation>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.NewEntryEvaluations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_NewEntryEvaluation_BaseSchoolName");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.NewEntryEvaluations)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_NewEntryEvaluation_CourseName");

                entity.HasOne(d => d.CourseModule)
                    .WithMany(p => p.NewEntryEvaluations)
                    .HasForeignKey(d => d.CourseModuleId)
                    .HasConstraintName("FK_NewEntryEvaluation_CourseModule");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.NewEntryEvaluations)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_NewEntryEvaluation_CourseDuration");

                entity.HasOne(d => d.CourseWeek)
                    .WithMany(p => p.NewEntryEvaluations)
                    .HasForeignKey(d => d.CourseWeekId)
                    .HasConstraintName("FK_NewEntryEvaluation_CourseWeek");


                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.NewEntryEvaluations)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_NewEntryEvaluation_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.NewEntryEvaluations)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_NewEntryEvaluation_TraineeNomination");

            });

            modelBuilder.Entity<Occupation>(entity =>
            {

            });
            modelBuilder.Entity<OrganizationName>(entity =>
            {
                entity.HasOne(d => d.ForceType)
                  .WithMany(p => p.OrganizationNames)
                  .HasForeignKey(d => d.ForceTypeId)
                  .HasConstraintName("FK_OrganizationName_ForceType");

            });

            modelBuilder.Entity<ParentRelative>(entity =>
            {

                entity.HasOne(d => d.DeadStatusNavigation)
                  .WithMany(p => p.ParentRelatives)
                  .HasForeignKey(d => d.DeadStatus)
                  .HasConstraintName("FK_ParentRelative_CodeValue");


                entity.HasOne(d => d.Caste)
                    .WithMany(p => p.ParentRelatives)
                    .HasForeignKey(d => d.CasteId)
                    .HasConstraintName("FK_ParentRelative_Caste");

                entity.HasOne(d => d.DefenseType)
                    .WithMany(p => p.ParentRelatives)
                    .HasForeignKey(d => d.DefenseTypeId)
                    .HasConstraintName("FK_ParentRelative_DefenseType");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.ParentRelatives)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_ParentRelative_District");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.ParentRelatives)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK_ParentRelative_Division");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.ParentRelatives)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .HasConstraintName("FK_ParentRelative_MaritalStatus");


                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.ParentRelativeNationalities)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_ParentRelative_Nationality");

                entity.HasOne(d => d.Occupation)
                    .WithMany(p => p.ParentRelativeOccupations)
                    .HasForeignKey(d => d.OccupationId)
                    .HasConstraintName("FK_ParentRelative_Occupation");

                entity.HasOne(d => d.PreviousOccupation)
                    .WithMany(p => p.ParentRelativePreviousOccupations)
                    .HasForeignKey(d => d.PreviousOccupationId)
                    .HasConstraintName("FK_ParentRelative_PreviousOccupation");


                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.ParentRelatives)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_ParentRelative_Rank");


                entity.HasOne(d => d.RelationType)
                    .WithMany(p => p.ParentRelatives)
                    .HasForeignKey(d => d.RelationTypeId)
                    .HasConstraintName("FK_ParentRelative_RelationType");


                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.ParentRelatives)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("FK_ParentRelative_Religion");

                entity.HasOne(d => d.SecondNationality)
                    .WithMany(p => p.ParentRelativeSecondNationalities)
                    .HasForeignKey(d => d.SecondNationalityId)
                    .HasConstraintName("FK_ParentRelative_SecondNationality");

                entity.HasOne(d => d.Thana)
                    .WithMany(p => p.ParentRelatives)
                    .HasForeignKey(d => d.ThanaId)
                    .HasConstraintName("FK_ParentRelative_Thana");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.ParentRelatives)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_ParentRelative_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<PaymentDetail>(entity =>
            {
                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.PaymentDetails)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_PaymentDetail_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<PresentBillet>(entity =>
            {

            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .HasConstraintName("FK_Question_QuestionType");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_Question_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {

            });

            modelBuilder.Entity<Rank>(entity =>
            {

            });

            modelBuilder.Entity<ReadingMaterial>(entity =>
            {


                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.ReadingMaterials)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_ReadingMaterial_BaseSchoolName");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.ReadingMaterials)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_ReadingMaterial_CourseName");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.ReadingMaterials)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_ReadingMaterial_DocumentType");

                entity.HasOne(d => d.DownloadRight)
                    .WithMany(p => p.ReadingMaterials)
                    .HasForeignKey(d => d.DownloadRightId)
                    .HasConstraintName("FK_ReadingMaterial_DownloadRight");


                entity.HasOne(d => d.ReadingMaterialTitle)
                       .WithMany(p => p.ReadingMaterials)
                       .HasForeignKey(d => d.ReadingMaterialTitleId)
                      .HasConstraintName("FK_ReadingMaterial_ReadingMaterialTitle");

                //entity.HasOne(d => d.ShowRight)
                //    .WithMany(p => p.ReadingMaterials)
                //    .HasForeignKey(d => d.ShowRightId)
                //    .HasConstraintName("FK_ReadingMaterial_RightSchoolName");
            });

            modelBuilder.Entity<ReasonType>(entity =>
            {

            });

            modelBuilder.Entity<RelationType>(entity =>
            {
                entity.ToTable("RelationType");
            });

           

            modelBuilder.Entity<Religion>(entity =>
            {

            });

            modelBuilder.Entity<ResultStatus>(entity =>
            {

            });


            modelBuilder.Entity<RoleFeature>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.FeatureKey });

                entity.ToTable("RoleFeature");


            });
            modelBuilder.Entity<RoutineNote>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.RoutineNotes)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_RoutineNote_BaseSchoolName");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.RoutineNotes)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_RoutineNote_BnaSubjectName");

                entity.HasOne(d => d.ClassRoutine)
                    .WithMany(p => p.RoutineNotes)
                    .HasForeignKey(d => d.ClassRoutineId)
                    .HasConstraintName("FK_RoutineNote_ClassRoutine");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.RoutineNotes)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_RoutineNote_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.RoutineNotes)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_RoutineNote_CourseName");
            });


            modelBuilder.Entity<SocialMediaType>(entity =>
            {

            });

            modelBuilder.Entity<SocialMedia>(entity =>
            {
                entity.HasOne(d => d.SocialMediaType)
                    .WithMany(p => p.SocialMedia)
                    .HasForeignKey(d => d.SocialMediaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SocialMedia_SocialMediaType");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.SocialMedia)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SocialMedia_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<StepRelation>(entity =>
            {

            });

            modelBuilder.Entity<SubjectCategory>(entity =>
            {

            });

            modelBuilder.Entity<SubjectClassification>(entity =>
            {

            });

            modelBuilder.Entity<SubjectCurriculum>(entity =>
            {

            });

            modelBuilder.Entity<SubjectMark>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.SubjectMarks)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_SubjectMark_BaseSchoolName");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.SubjectMarks)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_SubjectMark_BnaSubjectName");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.SubjectMarks)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_SubjectMark_Branch");

                entity.HasOne(d => d.CourseModule)
                    .WithMany(p => p.SubjectMarks)
                    .HasForeignKey(d => d.CourseModuleId)
                    .HasConstraintName("FK_SubjectMark_CourseModule");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.SubjectMarks)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_SubjectMark_CourseName");

                entity.HasOne(d => d.MarkType)
                    .WithMany(p => p.SubjectMarks)
                    .HasForeignKey(d => d.MarkTypeId)
                    .HasConstraintName("FK_SubjectMark_MarkType");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.SubjectMarks)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_SubjectMark_BnaSemester");

                entity.HasOne(d => d.BnaSubjectCurriculum)
                    .WithMany(p => p.SubjectMarks)
                    .HasForeignKey(d => d.BnaSubjectCurriculumId)
                    .HasConstraintName("FK_SubjectMark_BnaSubjectCurriculum");

                entity.HasOne(d => d.MarkCategory)
                    .WithMany(p => p.SubjectMarks)
                    .HasForeignKey(d => d.MarkCategoryId)
                    .HasConstraintName("FK_SubjectMark_MarkCategory");
            });

            modelBuilder.Entity<SubjectType>(entity =>
            {

            });

            modelBuilder.Entity<MarkCategory>(entity =>
            {

            });

            modelBuilder.Entity<SwimmingDriving>(entity =>
            {
                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.SwimmingDrivings)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SwimmingDriving_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<SwimmingDrivingLevel>(entity =>
            {
                entity.HasOne(d => d.LevelType)
                    .WithMany(p => p.SwimmingDrivingLevels)
                    .HasForeignKey(d => d.LevelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SwimmingDrivingLevel_CodeValue");

                entity.HasOne(d => d.SwimmingDriving)
                    .WithMany(p => p.SwimmingDrivingLevels)
                    .HasForeignKey(d => d.SwimmingDrivingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SwimmingDrivingLevel_SwimmingDriving");
            });

            modelBuilder.Entity<TdecQuationGroup>(entity =>
            {
                //entity.HasOne(d => d.Trainee)
                //    .WithMany(p => p.TdecQuationGroups)
                //    .HasForeignKey(d => d.TraineeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TdecQuationGroup_TraineeBioDataGeneralInfo");

                //entity.HasOne(d => d.BaseSchoolName)
                //    .WithMany(p => p.TdecQuationGroups)
                //    .HasForeignKey(d => d.BaseSchoolNameId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TdecQuationGroup_BaseSchoolName");

                //entity.HasOne(d => d.CourseName)
                //    .WithMany(p => p.TdecQuationGroups)
                //    .HasForeignKey(d => d.CourseNameId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TdecQuationGroup_CourseName");

                //entity.HasOne(d => d.CourseDuration)
                //    .WithMany(p => p.TdecQuationGroups)
                //    .HasForeignKey(d => d.CourseDurationId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TdecQuationGroup_CourseDuration");

                //entity.HasOne(d => d.BnaSubjectName)
                //    .WithMany(p => p.TdecQuationGroups)
                //    .HasForeignKey(d => d.BnaSubjectNameId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TdecQuationGroup_BnaSubjectName");

                //entity.HasOne(d => d.BnaExamInstructorAssign)
                //    .WithMany(p => p.TdecQuationGroups)
                //    .HasForeignKey(d => d.BnaExamInstructorAssignId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TdecQuationGroup_BnaExamInstructorAssign");

                //entity.HasOne(d => d.TdecQuestionName)
                //    .WithMany(p => p.TdecQuationGroups)
                //    .HasForeignKey(d => d.TdecQuestionNameId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TdecQuationGroup_TdecQuestionName1");

            });


            modelBuilder.Entity<TraineeAssignmentSubmit>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.TraineeAssignmentSubmits)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_TraineeAssignmentSubmit_BaseSchoolName");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.TraineeAssignmentSubmits)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_TraineeAssignmentSubmit_BnaSubjectName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.TraineeAssignmentSubmits)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_TraineeAssignmentSubmit_CourseDuration");

                entity.HasOne(d => d.CourseInstructor)
                    .WithMany(p => p.TraineeAssignmentSubmits)
                    .HasForeignKey(d => d.CourseInstructorId)
                    .HasConstraintName("FK_TraineeAssignmentSubmit_CourseInstructor");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.TraineeAssignmentSubmits)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_TraineeAssignmentSubmit_CourseName");

                entity.HasOne(d => d.InstructorAssignment)
                    .WithMany(p => p.TraineeAssignmentSubmits)
                    .HasForeignKey(d => d.InstructorAssignmentId)
                    .HasConstraintName("FK_TraineeAssignmentSubmit_InstructorAssignment");

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.TraineeAssignmentSubmitInstructors)
                    .HasForeignKey(d => d.InstructorId)
                    .HasConstraintName("FK_TraineeAssignmentSubmit_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeAssignmentSubmitTrainees)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_TraineeAssignmentSubmit_TraineeBioDataGeneralInfo1");
            });

            modelBuilder.Entity<TdecQuestionName>(entity =>
            {

            });

            modelBuilder.Entity<TdecActionStatus>(entity =>
            {

            });

            modelBuilder.Entity<TdecGroupResult>(entity =>
            {                

                //entity.HasOne(d => d.TdecActionStatus)
                //    .WithMany(p => p.TdecGroupResults)
                //    .HasForeignKey(d => d.TdecActionStatusId)
                //    .HasConstraintName("FK_TdecGroupResult_TdecActionStatus");

                //entity.HasOne(d => d.TdecQuationGroup)
                //    .WithMany(p => p.TdecGroupResults)
                //    .HasForeignKey(d => d.TdecQuationGroupId)
                //    .HasConstraintName("FK_TdecGroupResult_TdecQuationGroup");

                //entity.HasOne(d => d.TraineeNomination)
                //    .WithMany(p => p.TdecGroupResults)
                //    .HasForeignKey(d => d.TraineeNominationId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TdecGroupResult_TraineeNomination");
            });

            modelBuilder.Entity<Thana>(entity =>
            {
                entity.HasOne(d => d.District)
                    .WithMany(p => p.Thanas)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Thana_District");
            });

            modelBuilder.Entity<TraineeStatus>(entity =>
            {

            });

            modelBuilder.Entity<TraineeAssissmentGroup>(entity =>
            {

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.TraineeAssissmentGroups)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_TraineeAssissmentGroup_CourseDuration");

                entity.HasOne(d => d.TraineeAssissmentCreate)
                    .WithMany(p => p.TraineeAssissmentGroups)
                    .HasForeignKey(d => d.TraineeAssissmentCreateId)
                    .HasConstraintName("FK_TraineeAssissmentGroup_TraineeAssessmentCreate");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeAssissmentGroups)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_TraineeAssissmentGroup_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.TraineeAssissmentGroups)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_TraineeAssissmentGroup_TraineeNomination");
            });

            modelBuilder.Entity<SaylorBranch>(entity =>
            {

            });

            modelBuilder.Entity<SaylorRank>(entity =>
            {

            });

            modelBuilder.Entity<SaylorSubBranch>(entity =>
            {
                entity.HasOne(d => d.SaylorBranch)
                   .WithMany(p => p.SaylorSubBranches)
                   .HasForeignKey(d => d.SaylorBranchId)
                   .HasConstraintName("FK_SaylorSubBranch_SaylorBranch");

            });

            modelBuilder.Entity<TraineeAssessmentCreate>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.TraineeAssessmentCreates)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_TraineeAssessmentCreate_BaseSchoolName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.TraineeAssessmentCreates)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_TraineeAssessmentCreate_CourseDuration");
            });

            modelBuilder.Entity<TraineeAssessmentMark>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany()
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_TraineeAssessmentMark_BaseSchoolName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany()
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_TraineeAssessmentMark_CourseDuration");

                entity.HasOne(d => d.TraineeAssessmentCreate)
                    .WithMany()
                    .HasForeignKey(d => d.TraineeAssessmentCreateId)
                    .HasConstraintName("FK_TraineeAssessmentMark_TraineeAssessmentCreate");

                entity.HasOne(d => d.Trainee)
                    .WithMany()
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_TraineeAssessmentMark_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany()
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_TraineeAssessmentMark_TraineeNomination");
            });

            modelBuilder.Entity<TraineeBioDataGeneralInfo>(entity =>
            {
                entity.HasKey(e => e.TraineeId)
                    .HasName("PK_TraineeBIODataGeneralInfo");

                entity.HasOne(d => d.BloodGroup)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.BloodGroupId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_BloodGroup");

                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.BnaBatchId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_BnaBatch");


                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_Branch");

                entity.HasOne(d => d.Caste)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.CasteId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_Caste");

                entity.HasOne(d => d.ColorOfEye)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.ColorOfEyeId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_ColorOfEye");


                entity.HasOne(d => d.District)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_District");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_Division");


                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_Gender");

                entity.HasOne(d => d.HairColor)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.HairColorId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_HairColor");

                entity.HasOne(d => d.Height)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.HeightId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_Height");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_MaritalStatus");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.TraineeBioDataGeneralInfoNationalities)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_Nationality");

                entity.HasOne(d => d.Country)
                   .WithMany(p => p.TraineeBioDataGeneralInfos)
                   .HasForeignKey(d => d.CountryId)
                   .HasConstraintName("FK_TraineeBioDataGeneralInfo_Country");


                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_Rank");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_Religion");


                entity.HasOne(d => d.Thana)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.ThanaId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_Thana");

                entity.HasOne(d => d.TraineeStatus)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.TraineeStatusId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_TraineeStatus");


                entity.HasOne(d => d.SaylorBranch)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.SaylorBranchId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_SaylorBranch");


                entity.HasOne(d => d.SaylorRank)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.SaylorRankId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_SaylorRank");


                entity.HasOne(d => d.SaylorSubBranch)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.SaylorSubBranchId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_SaylorSubBranch");


                entity.HasOne(d => d.Weight)
                    .WithMany(p => p.TraineeBioDataGeneralInfos)
                    .HasForeignKey(d => d.WeightId)
                    .HasConstraintName("FK_TraineeBioDataGeneralInfo_Weight");
            });

            modelBuilder.Entity<TraineeBioDataOther>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_TraineeBioDataOther_BaseSchoolName");

                entity.HasOne(d => d.BloodGroup)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.BloodGroupId)
                    .HasConstraintName("FK_TraineeBioDataOther_BloodGroup");

                entity.HasOne(d => d.BnaClassSectionSelection)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.BnaClassSectionSelectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_BnaClassSectionSelection");

                entity.HasOne(d => d.BnaInstructorType)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.BnaInstructorTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_BnaInstructorType");

                entity.HasOne(d => d.BnaPromotionStatus)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.BnaPromotionStatusId)
                    .HasConstraintName("FK_TraineeBioDataOther_BnaPromotionStatus");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_BnaSemester");

                entity.HasOne(d => d.BnaServiceType)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.BnaServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_BnaServiceType");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_Branch");

                entity.HasOne(d => d.Caste)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.CasteId)
                    .HasConstraintName("FK_TraineeBioDataOther_Caste");

                entity.HasOne(d => d.ColorOfEye)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.ColorOfEyeId)
                    .HasConstraintName("FK_TraineeBioDataOther_ColorOfEye");

                entity.HasOne(d => d.Complexion)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.ComplexionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_Complexion");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_Country");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.CourseNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_CourseName");

                entity.HasOne(d => d.FailureStatus)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.FailureStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_FailureStatus");

                entity.HasOne(d => d.Height)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.HeightId)
                    .HasConstraintName("FK_TraineeBioDataOther_BnaCurriculumType");

                entity.HasOne(d => d.MaritalStatus)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.MaritalStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_MaritalStatus");

                entity.HasOne(d => d.PresentBillet)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.PresentBilletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_PresentBillet");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.ReligionId)
                    .HasConstraintName("FK_TraineeBioDataOther_Religion");

                entity.HasOne(d => d.Snationality)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.SnationalityId)
                    .HasConstraintName("FK_TraineeBioDataOther_Nationality");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.UtofficerCategory)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.UtofficerCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_UtofficerCategory");

                entity.HasOne(d => d.UtofficerType)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.UtofficerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeBioDataOther_UtofficerType");

                entity.HasOne(d => d.Weight)
                    .WithMany(p => p.TraineeBioDataOthers)
                    .HasForeignKey(d => d.WeightId)
                    .HasConstraintName("FK_TraineeBioDataOther_Weight");
            });

            modelBuilder.Entity<TraineeCourseStatus>(entity =>
            {

            });

            modelBuilder.Entity<TraineeLanguage>(entity =>
            {
                entity.HasOne(d => d.Language)
                    .WithMany(p => p.TraineeLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeLanguage_Language");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeLanguages)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeLanguage_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<TraineeMembership>(entity =>
            {
                entity.HasOne(d => d.MembershipType)
                    .WithMany(p => p.TraineeMemberships)
                    .HasForeignKey(d => d.MembershipTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeMembership_MembershipType");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeMemberships)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeMembership_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<RoutineSoftCopyUpload>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.RoutineSoftCopyUploads)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_RoutineSoftCopyUpload_BaseSchoolName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.RoutineSoftCopyUploads)
                    .HasForeignKey(d => d.CourseDurationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoutineSoftCopyUpload_CourseDuration");
            });

            modelBuilder.Entity<TraineeNomination>(entity =>
            {
                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_TraineeNomination_Branch");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_TraineeNomination_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_TraineeNomination_CourseName");

                entity.HasOne(d => d.ExamType)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.ExamTypeId)
                    .HasConstraintName("FK_TraineeNomination_ExamType");

                entity.HasOne(d => d.ExamAttemptType)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.ExamAttemptTypeId)
                    .HasConstraintName("FK_TraineeNomination_ExamAttemptType");

                entity.HasOne(d => d.TraineeCourseStatus)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.TraineeCourseStatusId)
                    .HasConstraintName("FK_TraineeNomination_TraineeCourseStatus");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_TraineeNomination_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.WithdrawnDoc)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.WithdrawnDocId)
                    .HasConstraintName("FK_TraineeNomination_WithdrawnDoc");

                entity.HasOne(d => d.ExamCenter)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.ExamCenterId)
                    .HasConstraintName("FK_TraineeNomination_ExamCenter");

                entity.HasOne(d => d.NewAtempt)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.NewAtemptId)
                    .HasConstraintName("FK_TraineeNomination_NewAtempt");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_TraineeNomination_Rank");

                entity.HasOne(d => d.SaylorBranch)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.SaylorBranchId)
                    .HasConstraintName("FK_TraineeNomination_SaylorBranch");

                entity.HasOne(d => d.SaylorRank)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.SaylorRankId)
                    .HasConstraintName("FK_TraineeNomination_SaylorRank");

                entity.HasOne(d => d.SaylorSubBranch)
                    .WithMany(p => p.TraineeNominations)
                    .HasForeignKey(d => d.SaylorSubBranchId)
                    .HasConstraintName("FK_TraineeNomination_SaylorSubBranch");

                entity.HasOne(d => d.BnaSemesterDuration)
                   .WithMany(p => p.TraineeNominations)
                   .HasForeignKey(d => d.BnaSemesterDurationId)
                   .HasConstraintName("FK_TraineeNomination_BnaSemesterDuration");
            });

            modelBuilder.Entity<TraineePicture>(entity =>
            {
                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.TraineePictures)
                    .HasForeignKey(d => d.BnaBatchId)
                    .HasConstraintName("FK_TraineePicture_BnaBatch");

                entity.HasOne(d => d.BnaSemesterDuration)
                    .WithMany(p => p.TraineePictures)
                    .HasForeignKey(d => d.BnaSemesterDurationId)
                    .HasConstraintName("FK_TraineePicture_BnaSemesterDuration");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.TraineePictures)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_TraineePicture_BnaSemester");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineePictures)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_TraineePicture_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<TraineeSectionSelection>(entity =>
            {
                entity.HasOne(d => d.BnaBatch)
                    .WithMany(p => p.TraineeSectionSelections)
                    .HasForeignKey(d => d.BnaBatchId)
                    .HasConstraintName("FK_TraineeSectionSelection_BnaBatch");

                entity.HasOne(d => d.BnaClassSectionSelection)
                    .WithMany(p => p.TraineeSectionSelectionBnaClassSectionSelections)
                    .HasForeignKey(d => d.BnaClassSectionSelectionId)
                    .HasConstraintName("FK_TraineeSectionSelection_BnaClassSectionSelection");

                entity.HasOne(d => d.BnaSemester)
                    .WithMany(p => p.TraineeSectionSelections)
                    .HasForeignKey(d => d.BnaSemesterId)
                    .HasConstraintName("FK_TraineeSectionSelection_BnaSemester");

                entity.HasOne(d => d.PreviewsSection)
                    .WithMany(p => p.TraineeSectionSelectionPreviewsSections)
                    .HasForeignKey(d => d.PreviewsSectionId)
                    .HasConstraintName("FK_TraineeSectionSelection_PreviousSection");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeSectionSelections)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeSectionSelection_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<Notice>(entity =>
            {
                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_Notice_CourseDuration");

                entity.HasOne(d => d.CourseInstructor)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.CourseInstructorId)
                    .HasConstraintName("FK_Notice_CourseInstructor");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_Notice_CourseName");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_Notice_TraineeNomination");

              entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.Notices)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_Notice_BaseSchoolName");

            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                  .WithMany(p => p.Notifications)
                  .HasForeignKey(d => d.SendBaseSchoolNameId)
                  .HasConstraintName("FK_Notification_BaseSchoolName");

                entity.HasOne(d => d.BaseSchoolName)
                  .WithMany(p => p.Notifications)
                  .HasForeignKey(d => d.ReceivedBaseSchoolNameId)
                  .HasConstraintName("FK_Notification_BaseSchoolName1");

            });

            modelBuilder.Entity<IndividualBulletin>(entity =>
            {

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.IndividualBulletins)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_IndividualBulletin_BaseSchoolName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.IndividualBulletins)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_IndividualBulletin_CourseDuration");

                entity.HasOne(d => d.CourseInstructor)
                    .WithMany(p => p.IndividualBulletins)
                    .HasForeignKey(d => d.CourseInstructorId)
                    .HasConstraintName("FK_IndividualBulletin_CourseInstructor");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.IndividualBulletins)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_IndividualBulletin_CourseName");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.IndividualBulletins)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_IndividualBulletin_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.IndividualBulletins)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_IndividualBulletin_TraineeNomination");
            });

            modelBuilder.Entity<IndividualNotice>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.IndividualNotices)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_IndividualNotice_BaseSchoolName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.IndividualNotices)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_IndividualNotice_CourseDuration");

                entity.HasOne(d => d.CourseInstructor)
                    .WithMany(p => p.IndividualNotices)
                    .HasForeignKey(d => d.CourseInstructorId)
                    .HasConstraintName("FK_IndividualNotice_CourseInstructor");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.IndividualNotices)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_IndividualNotice_CourseName");

                            entity.HasOne(d => d.Trainee)
                .WithMany(p => p.IndividualNotices)
                .HasForeignKey(d => d.TraineeId)
                .HasConstraintName("FK_IndividualNotice_TraineeBioDataGeneralInfo");

                entity.HasOne(d => d.TraineeNomination)
                    .WithMany(p => p.IndividualNotices)
                    .HasForeignKey(d => d.TraineeNominationId)
                    .HasConstraintName("FK_IndividualNotice_TraineeNomination");
            });

            modelBuilder.Entity<ForeignCourseOthersDocument>(entity =>
            {             
                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.ForeignCourseOthersDocuments)
                    .HasForeignKey(d => d.CourseDurationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ForeignCourseOthersDocument_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.ForeignCourseOthersDocuments)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_ForeignCourseOthersDocument_CourseName");

                entity.HasOne(d => d.ForeignCourseDocType)
                    .WithMany(p => p.ForeignCourseOthersDocuments)
                    .HasForeignKey(d => d.ForeignCourseDocTypeId)
                    .HasConstraintName("FK_ForeignCourseOthersDocument_ForeignCourseDocType");

                entity.HasOne(d => d.Trainee)
                  .WithMany(p => p.ForeignCourseOthersDocuments)
                  .HasForeignKey(d => d.TraineeId)
                  .HasConstraintName("FK_ForeignCourseOthersDocument_TraineeBioDataGeneralInfo");
            });


            modelBuilder.Entity<TraineeVisitedAboard>(entity =>
            {
                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TraineeVisitedAboards)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeVisitedAboard_Country");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.TraineeVisitedAboards)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TraineeVisitedAboard_TraineeBioDataGeneralInfo");
            });

            modelBuilder.Entity<TrainingObjective>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.TrainingObjectives)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_TrainingObjective_BaseSchoolName");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.TrainingObjectives)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_TrainingObjective_CourseName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.TrainingObjectives)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_TrainingObjective_CourseDuration");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.TrainingObjectives)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_TrainingObjective_BnaSubjectName"); 

                entity.HasOne(d => d.CourseTask)
                    .WithMany(p => p.TrainingObjectives)
                    .HasForeignKey(d => d.CourseTaskId)
                    .HasConstraintName("FK_TrainingObjective_CourseTask");

            });

            modelBuilder.Entity<TrainingSyllabus>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.TrainingSyllabus)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_TrainingSyllabus_BaseSchoolName");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.TrainingSyllabi)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_TrainingSyllabus_CourseName");

                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.TrainingSyllabi)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_TrainingSyllabus_CourseDuration");

                entity.HasOne(d => d.BnaSubjectName)
                    .WithMany(p => p.TrainingSyllabi)
                    .HasForeignKey(d => d.BnaSubjectNameId)
                    .HasConstraintName("FK_TrainingSyllabus_BnaSubjectName");

                entity.HasOne(d => d.CourseTask)
                    .WithMany(p => p.TrainingSyllabi)
                    .HasForeignKey(d => d.CourseTaskId)
                    .HasConstraintName("FK_TrainingSyllabus_CourseTask");

                entity.HasOne(d => d.TrainingObjective)
                    .WithMany(p => p.TrainingSyllabi)
                    .HasForeignKey(d => d.TrainingObjectiveId)
                    .HasConstraintName("FK_TrainingSyllabus_TrainingObjective");

            });

            modelBuilder.Entity<UserManual>(entity =>
            {

            });

            modelBuilder.Entity<UtofficerCategory>(entity =>
            {

            });

            modelBuilder.Entity<UtofficerType>(entity =>
            {

            });

            modelBuilder.Entity<WeekName>(entity =>
            {

            });

            modelBuilder.Entity<Weight>(entity =>
            {

            });

            modelBuilder.Entity<WithdrawnType>(entity =>
            {

            });

            modelBuilder.Entity<WithdrawnDoc>(entity =>
            {

            });

            modelBuilder.Entity<RecordOfService>(entity =>
            {
                entity.HasOne(d => d.Trainee)
                   .WithMany(p => p.RecordOfServices)
                   .HasForeignKey(d => d.TraineeId)
                   .HasConstraintName("FK_RecordOfService_TraineeBioDataGeneralInfo");

            });

            modelBuilder.Entity<ForeignTrainingCourseReport>(entity =>
            {
                entity.HasOne(d => d.CourseDuration)
                    .WithMany(p => p.ForeignTrainingCourseReports)
                    .HasForeignKey(d => d.CourseDurationId)
                    .HasConstraintName("FK_ForeignTrainingCourseReport_CourseDuration");

                entity.HasOne(d => d.CourseName)
                    .WithMany(p => p.ForeignTrainingCourseReports)
                    .HasForeignKey(d => d.CourseNameId)
                    .HasConstraintName("FK_ForeignTrainingCourseReport_CourseName");

                entity.HasOne(d => d.Trainee)
                    .WithMany(p => p.ForeignTrainingCourseReports)
                    .HasForeignKey(d => d.TraineeId)
                    .HasConstraintName("FK_ForeignTrainingCourseReport_TraineeBioDataGeneralInfo");

            });


        }


        public virtual DbSet<AccountType> AccountType { get; set; } = null!;
        public virtual DbSet<AdminAuthority> AdminAuthority { get; set; } = null!;
        public virtual DbSet<Allowance> Allowance { get; set; } = null!;
        public virtual DbSet<AllowanceCategory> AllowanceCategory { get; set; } = null!;
        public virtual DbSet<AllowancePercentage> AllowancePercentage { get; set; } = null!;
        public virtual DbSet<Assessment> Assessment { get; set; } = null!;
        public virtual DbSet<Attendance> Attendance { get; set; } = null!;
        public virtual DbSet<BaseName> BaseName { get; set; } = null!;
        public virtual DbSet<BaseSchoolName> BaseSchoolName { get; set; } = null!;
        public virtual DbSet<BloodGroup> BloodGroup { get; set; } = null!;
        public virtual DbSet<BnaAttendancePeriod> BnaAttendancePeriod { get; set; } = null!;
        public virtual DbSet<BnaAttendanceRemarks> BnaAttendanceRemarks { get; set; } = null!;
        public virtual DbSet<BnaBatch> BnaBatch { get; set; } = null!;
        public virtual DbSet<Notice> Notice { get; set; } = null!;
        public virtual DbSet<BnaClassSchedule> BnaClassSchedule { get; set; } = null!;
        public virtual DbSet<BnaClassScheduleStatus> BnaClassScheduleStatus { get; set; } = null!;
        public virtual DbSet<BnaClassSectionSelection> BnaClassSectionSelection { get; set; } = null!;
        public virtual DbSet<BnaClassTest> BnaClassTest { get; set; } = null!;
        public virtual DbSet<BnaClassTestType> BnaClassTestType { get; set; } = null!;
        public virtual DbSet<BnaCurriculumType> BnaCurriculumType { get; set; } = null!;
        public virtual DbSet<BnaCurriculumUpdate> BnaCurriculumUpdate { get; set; } = null!;
        public virtual DbSet<BnaExamAttendance> BnaExamAttendance { get; set; } = null!;
        public virtual DbSet<BnaExamInstructorAssign> BnaExamInstructorAssign { get; set; } = null!;
        public virtual DbSet<BnaExamMark> BnaExamMark { get; set; } = null!;
        public virtual DbSet<BnaExamRoutineLog> BnaExamRoutineLog { get; set; } = null!;
        public virtual DbSet<BnaExamSchedule> BnaExamSchedule { get; set; } = null!;
        public virtual DbSet<BnaInstructorType> BnaInstructorType { get; set; } = null!;
        public virtual DbSet<BnaPromotionLog> BnaPromotionLog { get; set; } = null!;
        public virtual DbSet<BnaPromotionStatus> BnaPromotionStatus { get; set; } = null!;
        public virtual DbSet<BnaSemester> BnaSemester { get; set; } = null!;
        public virtual DbSet<BnaSemesterDuration> BnaSemesterDuration { get; set; } = null!;
        public virtual DbSet<BnaServiceType> BnaServiceType { get; set; } = null!;
        public virtual DbSet<BnaSubjectCurriculum> BnaSubjectCurriculum { get; set; } = null!;
        public virtual DbSet<BnaSubjectName> BnaSubjectName { get; set; } = null!;
        public virtual DbSet<Board> Boards { get; set; } = null!;
        public virtual DbSet<Branch> Branch { get; set; } = null!;
        public virtual DbSet<AssignmentMarkEntry> AssignmentMarkEntry { get; set; } = null!;
        public virtual DbSet<Bulletin> Bulletin { get; set; } = null!; 
        public virtual DbSet<BudgetAllocation> BudgetAllocation { get; set; } = null!;
        public virtual DbSet<BudgetCode> BudgetCode { get; set; } = null!; 
        public virtual DbSet<BudgetType> BudgetType { get; set; } = null!; 
        public virtual DbSet<Caste> Caste { get; set; } = null!;
        public virtual DbSet<ClassInstructorAssign> ClassInstructorAssign { get; set; } = null!;
        public virtual DbSet<ClassPeriod> ClassPeriod { get; set; } = null!;
        public virtual DbSet<ClassRoutine> ClassRoutine { get; set; } = null!;
        public virtual DbSet<ClassType> ClassType { get; set; } = null!;
        public virtual DbSet<CoCurricularActivity> CoCurricularActivity { get; set; } = null!;
        public virtual DbSet<CoCurricularActivityType> CoCurricularActivityType { get; set; } = null!;
        public virtual DbSet<CodeValue> CodeValue { get; set; } = null!;
        public virtual DbSet<CodeValueType> CodeValueType { get; set; } = null!;
        public virtual DbSet<ColorOfEye> ColorOfEye { get; set; } = null!;
        public virtual DbSet<Complexion> Complexion { get; set; } = null!;
        public virtual DbSet<Country> Country { get; set; } = null!;
        public virtual DbSet<CountryGroup> CountryGroup { get; set; } = null!;
        public virtual DbSet<CurrencyName> CurrencyName { get; set; } = null!;
        public virtual DbSet<CourseDuration> CourseDuration { get; set; } = null!;
        public virtual DbSet<CourseGradingEntry> CourseGradingEntry { get; set; } = null!;
        public virtual DbSet<CourseInstructor> CourseInstructor { get; set; } = null!;
        public virtual DbSet<CourseNomenee> CourseNomenee { get; set; } = null!;
        public virtual DbSet<CourseModule> CourseModule { get; set; } = null!;
        public virtual DbSet<CourseName> CourseName { get; set; } = null!;
        public virtual DbSet<CoursePlanCreate> CoursePlanCreate { get; set; } = null!;
        public virtual DbSet<CourseType> CourseType { get; set; } = null!; 
        public virtual DbSet<CourseBudgetAllocation> CourseBudgetAllocation { get; set; } = null!;
        public virtual DbSet<CourseWeek> CourseWeek { get; set; } = null!;
        public virtual DbSet<DefenseType> DefenseType { get; set; } = null!;
        public virtual DbSet<District> District { get; set; } = null!;
        public virtual DbSet<Division> Division { get; set; } = null!;
        public virtual DbSet<Document> Document { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentType { get; set; } = null!;
        public virtual DbSet<DownloadRight> DownloadRight { get; set; } = null!;
        public virtual DbSet<EducationalInstitution> EducationalInstitution { get; set; } = null!;
        public virtual DbSet<EducationalQualification> EducationalQualification { get; set; } = null!;
        public virtual DbSet<Elected> Elected { get; set; } = null!;
        public virtual DbSet<Election> Election { get; set; } = null!;
        public virtual DbSet<EmploymentBeforeJoinBna> EmploymentBeforeJoinBna { get; set; } = null!;
        public virtual DbSet<Event> Event { get; set; } = null!;
        public virtual DbSet<ExamAttemptType> ExamAttemptType { get; set; } = null!;
        public virtual DbSet<ExamCenter> ExamCenter { get; set; } = null!;
        public virtual DbSet<ExamCenterSelection> ExamCenterSelection { get; set; } = null!;
        public virtual DbSet<ExamMarkRemarks> ExamMarkRemarks { get; set; } = null!;
        public virtual DbSet<ExamPeriodType> ExamPeriodType { get; set; } = null!;
        public virtual DbSet<ExamType> ExamType { get; set; } = null!;
        public virtual DbSet<FailureStatus> FailureStatus { get; set; } = null!;
        public virtual DbSet<ForeignCourseOtherDoc> ForeignCourseOtherDoc { get; set; } = null!;
        public virtual DbSet<FinancialSanction> FinancialSanction { get; set; } = null!;
        public virtual DbSet<ForeignCourseGOInfo> ForeignCourseGOInfo { get; set; } = null!;
        public virtual DbSet<FamilyInfo> FamilyInfo { get; set; } = null!;
        public virtual DbSet<Favorites> Favorites { get; set; } = null!;
        public virtual DbSet<FavoritesType> FavoritesType { get; set; } = null!; 
        public virtual DbSet<FamilyNomination> FamilyNomination { get; set; } = null!;
        public virtual DbSet<ForeignCourseDocType> ForeignCourseDocType { get; set; } = null!;
        public virtual DbSet<ForeignCourseOthersDocument> ForeignCourseOthersDocument { get; set; } = null!;
        public virtual DbSet<Feature> Feature { get; set; } = null!;
        public virtual DbSet<FiscalYear> FiscalYear { get; set; } = null!;
        public virtual DbSet<ForceType> ForceType { get; set; } = null!;
        public virtual DbSet<Game> Game { get; set; } = null!;
        public virtual DbSet<GameSport> GameSport { get; set; } = null!;
        public virtual DbSet<Gender> Gender { get; set; } = null!;
        public virtual DbSet<GrandFather> GrandFather { get; set; } = null!;
        public virtual DbSet<GrandFatherType> GrandFatherType { get; set; } = null!;
        public virtual DbSet<Group> Group { get; set; } = null!;
        //public virtual DbSet<Group> Group { get; set; } = null!; 
        public virtual DbSet<GuestSpeakerActionStatus> GuestSpeakerActionStatus { get; set; }
        public virtual DbSet<GuestSpeakerGroupResult> GuestSpeakerGroupResult { get; set; }
        public virtual DbSet<GuestSpeakerQuationGroup> GuestSpeakerQuationGroup { get; set; }
        public virtual DbSet<GuestSpeakerQuestionName> GuestSpeakerQuestionName { get; set; }
        public virtual DbSet<HairColor> HairColor { get; set; } = null!;
        public virtual DbSet<Height> Height { get; set; } = null!;
        public virtual DbSet<InstallmentPaidDetail> InstallmentPaidDetail { get; set; } = null!;
        public virtual DbSet<InterServiceMark> InterServiceMark { get; set; } = null!;
        public virtual DbSet<IndividualBulletin> IndividualBulletin { get; set; } = null!;
        public virtual DbSet<IndividualNotice> IndividualNotice { get; set; } = null!; 
        public virtual DbSet<InstructorAssignment> InstructorAssignment { get; set; } = null!;
        public virtual DbSet<JoiningReason> JoiningReason { get; set; } = null!;
        public virtual DbSet<KindOfSubject> KindOfSubject { get; set; } = null!;
        public virtual DbSet<Language> Language { get; set; } = null!;
        public virtual DbSet<MaritalStatus> MaritalStatus { get; set; } = null!;
        public virtual DbSet<MarkType> MarkType { get; set; } = null!;
        public virtual DbSet<MemberShipType> MemberShipType { get; set; } = null!;
        public virtual DbSet<MigrationDocument> MigrationDocument { get; set; } = null!;
        public virtual DbSet<Module> Module { get; set; } = null!;
        public virtual DbSet<Nationality> Nationality { get; set; } = null!;
        public virtual DbSet<NewAtempt> NewAtempt { get; set; } = null!;
        public virtual DbSet<NewEntryEvaluation> NewEntryEvaluation { get; set; } = null!;
        public virtual DbSet<Occupation> Occupation { get; set; } = null!;
        public virtual DbSet<OrganizationName> OrganizationName { get; set; } = null!;
        public virtual DbSet<ParentRelative> ParentRelative { get; set; } = null!;
        public virtual DbSet<PaymentDetail> PaymentDetail { get; set; } = null!;
        public virtual DbSet<PresentBillet> PresentBillet { get; set; } = null!;
        public virtual DbSet<PaymentType> PaymentType { get; set; } = null!; 
        public virtual DbSet<Question> Question { get; set; } = null!;
        public virtual DbSet<QuestionType> QuestionType { get; set; } = null!;
        public virtual DbSet<Rank> Rank { get; set; } = null!;
        public virtual DbSet<ReadingMaterial> ReadingMaterial { get; set; } = null!;
        public virtual DbSet<ReadingMaterialTitle> ReadingMaterialTitle { get; set; } = null!;
        public virtual DbSet<ReasonType> ReasonType { get; set; } = null!; 
        public virtual DbSet<RelationType> RelationType { get; set; } = null!;
        public virtual DbSet<Religion> Religion { get; set; } = null!;
        public virtual DbSet<ResultStatus> ResultStatus { get; set; } = null!;
        public virtual DbSet<RoleFeature> RoleFeature { get; set; } = null!; 
        public virtual DbSet<RoutineNote> RoutineNote { get; set; } = null!;
        public virtual DbSet<RoutineSoftCopyUpload> RoutineSoftCopyUpload { get; set; }
        public virtual DbSet<SocialMediaType> SocialMediaType { get; set; } = null!;
        public virtual DbSet<SocialMedia> SocialMedia { get; set; } = null!;
        public virtual DbSet<StepRelation> StepRelation { get; set; } = null!;
        public virtual DbSet<SubjectCategory> SubjectCategory { get; set; } = null!;
        public virtual DbSet<SubjectClassification> SubjectClassification { get; set; } = null!;
        public virtual DbSet<SubjectCurriculum> SubjectCurriculum { get; set; } = null!;
        public virtual DbSet<SubjectMark> SubjectMark { get; set; } = null!;
        public virtual DbSet<SubjectType> SubjectType { get; set; } = null!;
        public virtual DbSet<TdecActionStatus> TdecActionStatus { get; set; } = null!;
        public virtual DbSet<TdecGroupResult> TdecGroupResult { get; set; } = null!;
        public virtual DbSet<TdecQuationGroup> TdecQuationGroup { get; set; } = null!;
        public virtual DbSet<TdecQuestionName> TdecQuestionName { get; set; } = null!;
        public virtual DbSet<SwimmingDriving> SwimmingDriving { get; set; } = null!;
        public virtual DbSet<SwimmingDrivingLevel> SwimmingDrivingLevel { get; set; } = null!;
        public virtual DbSet<Thana> Thana { get; set; } = null!;
        public virtual DbSet<InterServiceCourseReport> InterServiceCourseReport { get; set; } = null!;
        public virtual DbSet<InterServiceCourseDocType> InterServiceCourseDocType { get; set; } = null!;
        public virtual DbSet<TraineeAssessmentCreate> TraineeAssessmentCreate { get; set; } = null!;
        public virtual DbSet<TraineeAssessmentMark> TraineeAssessmentMark { get; set; } = null!;
        public virtual DbSet<TraineeAssissmentGroup> TraineeAssissmentGroup { get; set; } = null!;
        public virtual DbSet<TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfo { get; set; } = null!;
        public virtual DbSet<TraineeBioDataOther> TraineeBioDataOther { get; set; } = null!;
        public virtual DbSet<TraineeCourseStatus> TraineeCourseStatus { get; set; } = null!;
        public virtual DbSet<TraineeLanguage> TraineeLanguage { get; set; } = null!;
        public virtual DbSet<TraineeMembership> TraineeMembership { get; set; } = null!;
        public virtual DbSet<TraineeNomination> TraineeNomination { get; set; } = null!;
        public virtual DbSet<TraineePicture> TraineePicture { get; set; } = null!;
        public virtual DbSet<TraineeSectionSelection> TraineeSectionSelection { get; set; } = null!;
        public virtual DbSet<TraineeVisitedAboard> TraineeVisitedAboard { get; set; } = null!;
        public virtual DbSet<TrainingObjective> TrainingObjective { get; set; } = null!; 
        public virtual DbSet<TraineeAssignmentSubmit> TraineeAssignmentSubmit { get; set; } = null!;
        public virtual DbSet<TrainingSyllabus> TrainingSyllabus { get; set; } = null!;
        public virtual DbSet<UserManual> UserManual { get; set; } = null!;
        public virtual DbSet<CourseTask> CourseTask { get; set; } = null!;
        public virtual DbSet<UtofficerCategory> UtofficerCategory { get; set; } = null!;
        public virtual DbSet<UtofficerType> UtofficerType { get; set; } = null!;
        public virtual DbSet<WeekName> WeekName { get; set; } = null!;
        public virtual DbSet<Weight> Weight { get; set; } = null!;  
        public virtual DbSet<WithdrawnType> WithdrawnType { get; set; } = null!;
        public virtual DbSet<WithdrawnDoc> WithdrawnDoc { get; set; } = null!;
        public virtual DbSet<RecordOfService> RecordOfService { get; set; } = null!;
        public virtual DbSet<CovidVaccine> CovidVaccine { get; set; } = null!;
        public virtual DbSet<Department> Department { get; set; } = null!;
        public virtual DbSet<MarkCategory> MarkCategory { get; set; } = null!;
        public virtual DbSet<ForeignTrainingCourseReport> ForeignTrainingCourseReport { get; set; } = null!;
        
    }
}
 