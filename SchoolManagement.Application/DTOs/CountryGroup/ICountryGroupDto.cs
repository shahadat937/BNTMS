namespace SchoolManagement.Application.DTOs.CountryGroup
{
    public interface ICountryGroupDto
    {
        public int CountryGroupId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
 