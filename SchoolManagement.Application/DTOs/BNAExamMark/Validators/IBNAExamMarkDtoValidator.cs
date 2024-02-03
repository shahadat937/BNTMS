using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaExamMark.Validators
{
    public class IBnaExamMarkDtoValidator : AbstractValidator<IBnaExamMarkDto>
    {
        public IBnaExamMarkDtoValidator()
        {
             
            //RuleFor(p => p.TraineeId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{Propertyname} must be at least 1.");
            ////RuleFor(p => p)
            ////    .NotEmpty().WithMessage("{Propertyname} is required.")
            ////    .NotNull()
            ////    .GreaterThan(0).WithMessage("{Propertyname} must be at least 1.");
            //RuleFor(p => p.BnaBatchId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{Propertyname} must be at least 1.");
            //RuleFor(p => p.BaseSchoolNameId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{Propertyname} must be at least 1.");
            //RuleFor(p => p.CourseNameId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{Propertyname} must be at least 1.");
            //RuleFor(p => p.ExamTypeId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{Propertyname} must be at least 1.");
            //RuleFor(p => p.BnaCurriculumTypeId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{Propertyname} must be at least 1.");
            //RuleFor(p => p.BnaSubjectNameId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{Propertyname} must be at least 1.");
            //RuleFor(p => p.BnaExamMarkRemarksId)
            //    .NotEmpty().WithMessage("{Propertyname} is required.")
            //    .NotNull()
            //    .GreaterThan(0).WithMessage("{Propertyname} must be at least 1.");


        }
    }
}
