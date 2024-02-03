using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaClassTest.Validators
{

    public class UpdateBnaClassTestDtoValidator : AbstractValidator<BnaClassTestDto>
        {
        public UpdateBnaClassTestDtoValidator()
        {
            Include(new IBnaClassTestDtoValidator());

            RuleFor(p => p.BnaClassTestId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
