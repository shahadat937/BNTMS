using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaSemester.Validators
{
    public class UpdateBnaSemesterDtoValidator : AbstractValidator<BnaSemesterDto>
    {
        public UpdateBnaSemesterDtoValidator()
        {
            Include(new IBnaSemesterDtoValidator());

            RuleFor(p => p.BnaSemesterId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
