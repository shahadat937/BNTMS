using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ForeignCourseOthersDocument.Validators
{
    public class CreateForeignCourseOthersDocumentDtoValidator : AbstractValidator<CreateForeignCourseOthersDocumentDto>
    {
        public CreateForeignCourseOthersDocumentDtoValidator()
        {
            Include(new IForeignCourseOthersDocumentDtoValidator());
        }
    }
}
