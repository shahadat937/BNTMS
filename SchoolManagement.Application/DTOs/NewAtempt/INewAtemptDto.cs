namespace SchoolManagement.Application.DTOs.NewAtempt
{
    public interface INewAtemptDto
    {
        public int NewAtemptId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
 