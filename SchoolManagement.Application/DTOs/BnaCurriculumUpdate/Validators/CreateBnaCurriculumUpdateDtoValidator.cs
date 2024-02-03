using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaCurriculumUpdate.Validators
{
    public class CreateBnaCurriculumUpdateDtoValidator : AbstractValidator<CreateBnaCurriculumUpdateDto>
    {
        public CreateBnaCurriculumUpdateDtoValidator()
        {
            Include(new IBnaCurriculumUpdateDtoValidator());
        }
    }
}
