﻿namespace SchoolManagement.Application.DTOs.CurrencyName
{
    public class CreateCurrencyNameDto : ICurrencyNameDto 
    {
        public int CurrencyNameId { get; set; }
        public int? CountryId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
 