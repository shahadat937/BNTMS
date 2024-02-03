using FluentValidation;

namespace SchoolManagement.Application.DTOs.ClassPeriod.Validators
{
   public class CreateClassPeriodDtoValidator : AbstractValidator<CreateClassPeriodDto>
    {
        public CreateClassPeriodDtoValidator()
        {
            Include(new IClassPeriodDtoValidator());
        }
    }
}
 