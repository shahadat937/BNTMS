using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaClassTest.Validators
{
    public class CreateBnaClassTestDtoValidator : AbstractValidator<CreateBnaClassTestDto>
    {
        public CreateBnaClassTestDtoValidator()
        {
            Include(new IBnaClassTestDtoValidator());
        }
    }
}
