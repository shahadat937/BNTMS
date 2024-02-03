using FluentValidation;

namespace SchoolManagement.Application.DTOs.MigrationDocument.Validators
{
    public class UpdateMigrationDocumentDtoValidator : AbstractValidator<MigrationDocumentDto>
    { 
        public UpdateMigrationDocumentDtoValidator()
        {
            Include(new IMigrationDocumentDtoValidator());

            RuleFor(p => p.MigrationDocumentId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
