using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Allowance : BaseDomainEntity
    {
        public int AllowanceId { get; set; }
        public int? AllowanceCategoryId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CountryId { get; set; }
        public int? FromRankId { get; set; }
        public int? ToRankId { get; set; }
        public DateTime? DurationFrom { get; set; }
        public DateTime? DurationTo { get; set; }
        public string? Vacancy { get; set; }
        public string? ProvideByAuthority { get; set; }
        public int? Tarminal { get; set; }
        public int? Transit { get; set; }
        public int? BankCommission { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual AllowanceCategory? AllowanceCategory { get; set; }
        public virtual Rank? FromRank { get; set; }
        public virtual Rank? ToRank { get; set; }
        public virtual Country? Country { get; set; }
        public virtual CourseName? CourseName { get; set; }




    }
}
