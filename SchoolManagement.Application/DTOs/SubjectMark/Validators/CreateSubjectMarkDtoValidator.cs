using FluentValidation;

namespace SchoolManagement.Application.DTOs.SubjectMark.Validators
{
    public class CreateSubjectMarkDtoValidator : AbstractValidator<CreateSubjectMarkDto> 
    {
        public CreateSubjectMarkDtoValidator()
        {
            Include(new ISubjectMarkDtoValidator());
        }
    }
}
