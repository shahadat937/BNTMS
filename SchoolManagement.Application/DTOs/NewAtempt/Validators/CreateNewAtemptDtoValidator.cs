using FluentValidation;

namespace SchoolManagement.Application.DTOs.NewAtempt.Validators
{
   public class CreateNewAtemptDtoValidator: AbstractValidator<CreateNewAtemptDto>
    {
        public CreateNewAtemptDtoValidator()
        {
            Include(new INewAtemptDtoValidator());
        }
    }
}
