namespace SchoolManagement.Application.DTOs.NewAtempt
{
    public class CreateNewAtemptDto : INewAtemptDto 
    {
        public int NewAtemptId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
 