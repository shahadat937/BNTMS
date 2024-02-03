using FluentValidation;

namespace SchoolManagement.Application.DTOs.DocumentTypes.Validators
{ 
   public class CreateDocumentTypeDtoValidator : AbstractValidator<CreateDocumentTypeDto>
    {
        public CreateDocumentTypeDtoValidator()
        {
            Include(new IDocumentTypeDtoValidator());
        }
    }
}
