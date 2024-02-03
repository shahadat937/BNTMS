using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaCurriculumUpdate.Validators
{
    public class UpdateBnaCurriculumUpdateDtoValidator : AbstractValidator<BnaCurriculumUpdateDto>
    {
        public UpdateBnaCurriculumUpdateDtoValidator() 
        {
            Include(new IBnaCurriculumUpdateDtoValidator());

            //RuleFor(p => p.BnaBatchId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaCurriculumTypeId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaSemesterId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaSemesterDurationId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
