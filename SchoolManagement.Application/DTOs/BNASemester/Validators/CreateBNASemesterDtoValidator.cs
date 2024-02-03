using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaSemester.Validators
{
    public class CreateBnaSemesterDtoValidator : AbstractValidator<CreateBnaSemesterDto>
    {
        public CreateBnaSemesterDtoValidator()
        {
            Include(new IBnaSemesterDtoValidator());
        }
    }
}
