using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseOthersDocument.Validators
{
    public class IForeignCourseOthersDocumentDtoValidator : AbstractValidator<IForeignCourseOthersDocumentDto>
    {
        public IForeignCourseOthersDocumentDtoValidator()
        {
            //RuleFor(b => b.)
            //    .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
