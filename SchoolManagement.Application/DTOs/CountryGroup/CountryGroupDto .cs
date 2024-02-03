namespace SchoolManagement.Application.DTOs.CountryGroup
{
    public class CountryGroupDto: ICountryGroupDto
    {
        public int CountryGroupId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
