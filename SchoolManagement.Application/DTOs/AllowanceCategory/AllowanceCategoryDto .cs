namespace SchoolManagement.Application.DTOs.AllowanceCategory
{
    public class AllowanceCategoryDto: IAllowanceCategoryDto
    {
        public int AllowanceCategoryId { get; set; }
        public int? FromRankId { get; set; }
        public int? ToRankId { get; set; }
        public int? CountryGroupId { get; set; }
        public int? CountryId { get; set; }
        public int? CurrencyNameId { get; set; }
        public int? AllowancePercentageId { get; set; }
        public int? DailyPayment { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? FromRank { get; set; }
        public string? ToRank { get; set; }
        public string? CountryGroup { get; set; }
        public string? Country { get; set; }
        public string? CurrencyName { get; set; }
        public string? AllowancePercentage { get; set; }


    }
}
