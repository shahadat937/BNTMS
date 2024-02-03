using FluentValidation;

namespace SchoolManagement.Application.DTOs.RoutineNote.Validators
{
    public class IRoutineNoteDtoValidator : AbstractValidator<IRoutineNoteDto>
    {
        public IRoutineNoteDtoValidator()
        {
            //RuleFor(p => p.CastName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            //RuleFor(p => p.ReligionId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");

            
        }
    }
}
