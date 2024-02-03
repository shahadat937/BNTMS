using FluentValidation;

namespace SchoolManagement.Application.DTOs.TdecGroupResult.Validators
{
    public class ITdecGroupResultDtoValidator : AbstractValidator<ITdecGroupResultDto>
    {
        public ITdecGroupResultDtoValidator()
        {
           //RuleFor(c => c.BaseSchoolNameId)
           //    .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} is greather than zero.");

        }
        
    }
}
