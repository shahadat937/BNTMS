using FluentValidation;


namespace SchoolManagement.Application.DTOs.DocumentTypes.Validators
{
    public class IDocumentTypeDtoValidator : AbstractValidator<IDocumentTypeDto>
    {
        public IDocumentTypeDtoValidator()
        {
            RuleFor(c => c.DocumentTypeName)
               .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
 