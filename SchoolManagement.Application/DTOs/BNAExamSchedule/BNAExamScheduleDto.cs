using System;

namespace SchoolManagement.Application.DTOs.BnaExamSchedule
{
    public class BnaExamScheduleDto : IBnaExamScheduleDto
    {
        public int BnaExamScheduleId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? ExamTypeId { get; set; }
        public DateTime? DurationFrom { get; set; }
        public DateTime? ExamDate { get; set; }
        public DateTime? DurationTo { get; set; }
        public string? ExamLocation { get; set; }
        public int? ExamSheduleStatus { get; set; }
        public int? IsApproved { get; set; }
        public string? ApprovedBy { get; set; }
        public DateTime? IsApprovedDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? BnaSemester { get; set; }
        public string? BnaBatch { get; set; }
        public string? ExamType { get; set; }
        public string? BnaSubjectName { get; set; }
    }
}
