namespace SchoolManagement.Application.DTOs.MilitaryTraining
{
    public interface IMilitaryTrainingDto
    {
        public int MilitaryTrainingId { get; set; }
        public int? TraineeId { get; set; }
        public DateTime? DateAttended { get; set; }
        public string? LocationOfTrg { get; set; }
        public string? DetailsOfCourse { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 