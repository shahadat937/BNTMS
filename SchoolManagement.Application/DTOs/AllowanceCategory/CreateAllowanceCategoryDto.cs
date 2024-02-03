namespace SchoolManagement.Application.DTOs.AllowanceCategory
{
    public class CreateAllowanceCategoryDto : IAllowanceCategoryDto 
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
    }
}
 