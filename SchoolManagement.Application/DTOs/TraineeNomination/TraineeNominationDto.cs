
namespace SchoolManagement.Application.DTOs.TraineeNomination
{
    public class TraineeNominationDto : ITraineeNominationDto
    {
        public int TraineeNominationId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? DepartmentId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? ExamAttemptTypeId { get; set; }
        public int? ExamTypeId { get; set; }
        public int? TraineeId { get; set; }
        public int? SaylorRankId { get; set; }
        public int? RankId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? SaylorBranchId { get; set; }
        public int? SaylorSubBranchId { get; set; }
        public int? BranchId { get; set; }
        public int? CourseAttendState { get; set; }
        public string? CertificateSerialNo { get; set; }
        public string? CourseAttendStateRemark { get; set; }
        public int? ExamCenterId { get; set; }
        public int? NewAtemptId { get; set; }
        public string? IndexNo { get; set; }
        public string? PresentBillet { get; set; }
        public string? FamilyAllowId { get; set; }
        public int? TraineeCourseStatusId { get; set; }
        public int? WithdrawnDocId { get; set; } 
        public int? WithdrawnTypeId { get; set; }
        public string? WithdrawnRemarks { get; set; }
        public DateTime? WithdrawnDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? BnaAttendanceRemarksId { get; set; }
        public bool? AttendanceStatus { get; set; }        
        public string? ClassLeaderName { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public string? CourseDuration { get; set; }
        public string? TraineeCourseStatus { get; set; }
        public string? CourseName { get; set; }
        public string? WithdrawnDoc { get; set; }
        public string? TraineeName { get; set;}
        public string? RankName { get; set; } 
        public string? TraineePNo { get; set; } 
        public string? RankPosition { get; set; }
        public string? SchoolName { get; set; }
        public string? ExamCenter { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? Ticket { get; set; }
        public bool? Visa { get; set; }
        public bool? Passport { get; set; }
        public bool? CovidTest { get; set; }
        public bool? MedicalTest { get; set; }
        public bool? DgfiBreafing { get; set; }
        public bool? DniBreafing { get; set; }
        public bool? EmbassiBreafing { get; set; }
        public bool? FinancialSanction { get; set; }
        public bool? ExBdLeave { get; set; } 
        public string? FamilyGo { get; set; }
        public bool? MedicalDocument { get; set; }
        public string? Remark { get; set; }
        public int? ForeignCourseOtherDocId { get; set; } 
        public string? Trainee { get; set; } 
        public string? NewAtempt { get; set; } 
        public DateTime? TraineeDOB { get; set; } 
        public DateTime? TraineeJoiningDate { get; set; }

        public string? saylorBranch { get; set; }
        public string? SaylorRank { get; set; }
        public int? TraineeStatusId { get; set; }
        public string? WithdrawnType { get; set; } 

        //public DateTime? ApprovedDate { get; set; }
        //public int? Status { get; set; }
        //public int? MenuPosition { get; set; }
        //public bool IsActive { get; set; }

    }
}
