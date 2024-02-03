namespace SchoolManagement.Application.DTOs.BnaServiceType
{
    public class CreateBnaServiceTypeDto : IBnaServiceTypeDto
    {
        public int BnaServiceTypeId { get; set; }
        public string ServiceName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
