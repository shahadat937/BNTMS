namespace SchoolManagement.Application.DTOs.DownloadRight
{
    public interface IDownloadRightDto
    {
        public int DownloadRightId { get; set; }
        public string? DownloadRightName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
