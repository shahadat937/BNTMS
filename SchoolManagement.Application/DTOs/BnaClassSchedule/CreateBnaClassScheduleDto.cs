using System;

namespace SchoolManagement.Application.DTOs.BnaClassSchedule
{
    public class CreateBnaClassScheduleDto : IBnaClassScheduleDto
    {
        public int BnaClassScheduleId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? BnaClassSectionSelectionId { get; set; }
        public int? ClassPeriodId { get; set; }
        public int? BnaClassScheduleStatusId { get; set; }
        public int? TraineeId { get; set; }
        public DateTime? Date { get; set; }
        public string? ClassLocation { get; set; }
        public bool ClassCompletedStatus { get; set; }
        public string? DurationForm { get; set; }
        public string? DurationTo { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
