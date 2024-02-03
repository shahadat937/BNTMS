using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaCurriculamType.Validators
{
    public class UpdateBnaCurriculamTypeDtoValidator: AbstractValidator<BnaCurriculamTypeDto>
    {
        public UpdateBnaCurriculamTypeDtoValidator()
        {
            Include(new IBnaCurriculamTypeDtoValidator());

            RuleFor(c => c.BnaCurriculumTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
