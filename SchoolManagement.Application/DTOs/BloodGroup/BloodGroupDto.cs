namespace SchoolManagement.Application.DTOs.BloodGroup
{
    public class BloodGroupDto : IBloodGroupDto
    {
        public int BloodGroupId { get; set; }
        public string BloodGroupName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
