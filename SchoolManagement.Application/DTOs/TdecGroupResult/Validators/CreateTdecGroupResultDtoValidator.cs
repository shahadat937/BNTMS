
using FluentValidation;

namespace SchoolManagement.Application.DTOs.TdecGroupResult.Validators
{
    public class CreateTdecGroupResultDtoValidator : AbstractValidator<CreateTdecGroupResultDto>
    {
        public CreateTdecGroupResultDtoValidator()
        {
            Include(new ITdecGroupResultDtoValidator());
        }
    }
}
