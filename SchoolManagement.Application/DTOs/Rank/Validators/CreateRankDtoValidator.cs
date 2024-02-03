using FluentValidation;

namespace SchoolManagement.Application.DTOs.Rank.Validators
{
    public class CreateRankDtoValidator : AbstractValidator<CreateRankDto>
    {
        public CreateRankDtoValidator()
        {
            Include(new IRankDtoValidator());
        }
    }
}
