using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Document.Validators
{
    public class UpdateDocumentDtoValidator : AbstractValidator<CreateDocumentDto>
    {
        public UpdateDocumentDtoValidator()
        {
            Include(new IDocumentDtoValidator());

           // RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
