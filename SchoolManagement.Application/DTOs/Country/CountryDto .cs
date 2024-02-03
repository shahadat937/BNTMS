using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Country
{
    public class CountryDto : ICountryDto
    {
        public int CountryId { get; set; }
        public int? CountryGroupId { get; set; }
        public int? CurrencyNameId { get; set; }
        public string CountryName { get; set; } = null!;
        public int? CurrentPrice { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
