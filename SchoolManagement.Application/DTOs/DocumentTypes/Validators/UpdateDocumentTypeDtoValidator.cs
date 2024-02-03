using FluentValidation;


namespace SchoolManagement.Application.DTOs.DocumentTypes.Validators
{
    public class UpdateDocumentTypeDtoValidator : AbstractValidator<DocumentTypeDto>
    {
        public UpdateDocumentTypeDtoValidator()
        {
            Include(new IDocumentTypeDtoValidator());

            RuleFor(c => c.DocumentTypeName).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
 