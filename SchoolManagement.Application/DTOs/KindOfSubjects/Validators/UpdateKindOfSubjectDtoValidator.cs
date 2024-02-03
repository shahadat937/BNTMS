using FluentValidation;

namespace SchoolManagement.Application.DTOs.KindOfSubjects.Validators
{
    public class UpdateKindOfSubjectDtoValidator : AbstractValidator<KindOfSubjectDto>
    {
        public UpdateKindOfSubjectDtoValidator()
        {
            Include(new IKindOfSubjectDtoValidator());

            RuleFor(p => p.KindOfSubjectId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
 