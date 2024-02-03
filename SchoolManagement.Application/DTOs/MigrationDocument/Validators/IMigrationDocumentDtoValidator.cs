using FluentValidation;

namespace SchoolManagement.Application.DTOs.MigrationDocument.Validators
{
    public class IMigrationDocumentDtoValidator : AbstractValidator<IMigrationDocumentDto>
    {
        public IMigrationDocumentDtoValidator()
        {
            //RuleFor(p => p.MigrationDocumentName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
