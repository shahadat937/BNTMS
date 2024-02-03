namespace SchoolManagement.Application.DTOs.CountryGroup
{
    public class CreateCountryGroupDto : ICountryGroupDto 
    {
        public int CountryGroupId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
 