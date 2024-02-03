using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaExamMark.Validators
{
    public class UpdateBnaExamMarkDtoValidator : AbstractValidator<BnaExamMarkDto>
    {
        public UpdateBnaExamMarkDtoValidator()
        {
            Include(new IBnaExamMarkDtoValidator());

            //RuleFor(p => p.TraineeId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.BnaSemesterId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.BnaBatchId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.BaseSchoolNameId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.CourseNameId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.ExamTypeId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.BnaExamScheduleId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.BnaCurriculumTypeId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.BnaSubjectNameId).NotNull().WithMessage("{Propertyname} must be present");
            //RuleFor(p => p.BnaExamMarkRemarksId).NotNull().WithMessage("{Propertyname} must be present");

        }
    }
}
