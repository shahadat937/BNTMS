namespace SchoolManagement.Application.DTOs.ExamCenterSelection
{
    public class CreateExamCenterSelectionDto : IExamCenterSelectionDto
    {
        public int ExamCenterSelectionId { get; set; }
        public int TraineeNominationId { get; set; }
        public int BnaExamScheduleId { get; set; }
        public int ExamCenterId { get; set; }
        public int TraineeId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 