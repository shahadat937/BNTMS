using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SubjectCategorys.Validators 
{
    public class UpdateSubjectCategoryDtoValidator : AbstractValidator<SubjectCategoryDto>
    {
        public UpdateSubjectCategoryDtoValidator()
        {
            Include(new ISubjectCategoryDtoValidator());

            RuleFor(b => b.SubjectCategoryId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
