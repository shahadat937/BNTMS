using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseOthersDocument.Validators
{
    public class UpdateForeignCourseOthersDocumentDtoValidator : AbstractValidator<ForeignCourseOthersDocumentDto>
    {
        public UpdateForeignCourseOthersDocumentDtoValidator()
        {
            Include(new IForeignCourseOthersDocumentDtoValidator());

            RuleFor(p => p.ForeignCourseOthersDocumentId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
