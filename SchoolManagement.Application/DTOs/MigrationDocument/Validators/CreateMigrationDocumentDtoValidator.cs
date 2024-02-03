using FluentValidation;

namespace SchoolManagement.Application.DTOs.MigrationDocument.Validators
{
    public class CreateMigrationDocumentDtoValidator:AbstractValidator<CreateMigrationDocumentDto>
    {
        public CreateMigrationDocumentDtoValidator()
        {
            Include(new IMigrationDocumentDtoValidator());
        }
    }
}
