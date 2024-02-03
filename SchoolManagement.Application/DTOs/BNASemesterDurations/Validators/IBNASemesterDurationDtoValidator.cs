using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaSemesterDurations.Validators
{
    public class IBnaSemesterDurationDtoValidator : AbstractValidator<IBnaSemesterDurationDto>
    { 
        public IBnaSemesterDurationDtoValidator()
        {
            //RuleFor(p => p.BnaSemesterId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.");

            //RuleFor(p => p.BnaBatchId)
            //   .NotEmpty().WithMessage("{Propertyname} is required.");

            //RuleFor(p => p.RankId)
            //   .NotEmpty().WithMessage("{Propertyname} is required.");

            //RuleFor(p => p.NextSemesterId)
            //   .NotEmpty().WithMessage("{Propertyname} is required.");
        }
    }
}
