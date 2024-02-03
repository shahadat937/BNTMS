using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.ReadingMaterial.Validators
{
    public class UpdateReadingMaterialDtoValidator : AbstractValidator<ReadingMaterialDto>
    {
        public UpdateReadingMaterialDtoValidator()
        {
            //Include(new IReadingMaterialDtoValidator());

            //RuleFor(p => p.CourseNameId).NotNull().WithMessage("{PropertyName} must be present");

            //RuleFor(p => p.BaseSchoolNameId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.DocumentTypeId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.DownloadRightId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.ShowRightId).NotNull().WithMessage("{PropertyName} must be present");
            
        }
    }
}
