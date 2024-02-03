namespace SchoolManagement.Application.DTOs.TdecGroupResult
{
    public class CreateTdecGroupResultDto : ITdecGroupResultDto
    {
        public int? BnaExamScheduleId { get; set; }
        public int? TraineeId { get; set; }
        public string? Remarks { get; set; }
        public List<ApproveTraineeListForm> ApproveTraineeListForm { get; set; }
        public bool? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
