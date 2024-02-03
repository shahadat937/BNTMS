using FluentValidation;

namespace SchoolManagement.Application.DTOs.InterServiceMark.Validators
{
   public class CreateInterServiceMarkDtoValidator: AbstractValidator<CreateInterServiceMarkDto>
    {
        public CreateInterServiceMarkDtoValidator()
        {
            Include(new IInterServiceMarkDtoValidator());
        }
    }
}
