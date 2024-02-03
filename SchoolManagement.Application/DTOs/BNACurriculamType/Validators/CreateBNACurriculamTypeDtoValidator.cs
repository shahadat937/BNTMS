using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaCurriculamType.Validators
{
   public class CreateBnaCurriculamTypeDtoValidator: AbstractValidator<CreateBnaCurriculamTypeDto>
    {
        public CreateBnaCurriculamTypeDtoValidator()
        {
            Include(new IBnaCurriculamTypeDtoValidator());
        }
    }
}
