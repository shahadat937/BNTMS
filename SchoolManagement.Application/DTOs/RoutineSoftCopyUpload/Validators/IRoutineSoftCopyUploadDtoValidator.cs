using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.RoutineSoftCopyUpload.Validators
{
    public class IRoutineSoftCopyUploadDtoValidator : AbstractValidator<IRoutineSoftCopyUploadDto>
    {
        public IRoutineSoftCopyUploadDtoValidator()
        {
            

            //RuleFor(p => p.CourseNameId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            //RuleFor(p => p.BaseSchoolNameId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            //RuleFor(p => p.DocumentTypeId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            //RuleFor(p => p.DownloadRightId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            //RuleFor(p => p.ShowRightId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.");
            
            //RuleFor(p => p.MaterialTitle)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            //RuleFor(p => p.DocumentName)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            

        }
    }
}
