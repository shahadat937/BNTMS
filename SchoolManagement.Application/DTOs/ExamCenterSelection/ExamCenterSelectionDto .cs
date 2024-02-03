namespace SchoolManagement.Application.DTOs.ExamCenterSelection
{
    public class ExamCenterSelectionDto : IExamCenterSelectionDto
    {
        public int ExamCenterSelectionId { get; set; }
        public int TraineeNominationId { get; set; }
        public int BnaExamScheduleId { get; set; }
        public int ExamCenterId { get; set; }
        public int TraineeId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? TraineeNomination { get; set; }
        public string? BnaExamSchedule { get; set; }
        public string? ExamCenter { get; set; }
    }
}
