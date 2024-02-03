using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;


namespace SchoolManagement.Application.DTOs.RoutineSoftCopyUpload.Validators
{
    public class UpdateRoutineSoftCopyUploadDtoValidator : AbstractValidator<RoutineSoftCopyUploadDto>
    {
        public UpdateRoutineSoftCopyUploadDtoValidator()
        {
            //Include(new IRoutineSoftCopyUploadDtoValidator());

            //RuleFor(p => p.CourseNameId).NotNull().WithMessage("{PropertyName} must be present");

            //RuleFor(p => p.BaseSchoolNameId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.DocumentTypeId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.DownloadRightId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.ShowRightId).NotNull().WithMessage("{PropertyName} must be present");
            
        }
    }
}
