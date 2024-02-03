using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaBatch.Validators
{
    public class CreateBnaBatchDtoValidator : AbstractValidator<CreateBnaBatchDto>
    {
        public CreateBnaBatchDtoValidator()
        {
            Include(new IBnaBatchDtoValidator());
        }
    }
}
 