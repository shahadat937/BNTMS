using FluentValidation;

namespace SchoolManagement.Application.DTOs.SubjectMark.Validators
{
    public class UpdateSubjectMarkDtoValidator : AbstractValidator<SubjectMarkDto>
    { 
        public UpdateSubjectMarkDtoValidator()
        {
            Include(new ISubjectMarkDtoValidator());

            RuleFor(b => b.SubjectMarkId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
