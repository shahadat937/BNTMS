using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SubjectCategorys.Validators 
{
    public class CreateSubjectCategoryDtoValidator : AbstractValidator<CreateSubjectCategoryDto>
    {
        public CreateSubjectCategoryDtoValidator()
        {
            Include(new ISubjectCategoryDtoValidator());
        }
    } 
}
