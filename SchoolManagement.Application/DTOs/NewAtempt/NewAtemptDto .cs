namespace SchoolManagement.Application.DTOs.NewAtempt
{
    public class NewAtemptDto: INewAtemptDto
    {
        public int NewAtemptId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
