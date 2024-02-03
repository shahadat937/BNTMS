using FluentValidation;
 
namespace SchoolManagement.Application.DTOs.KindOfSubjects.Validators
{
    public class CreateKindOfSubjectDtoValidator : AbstractValidator<CreateKindOfSubjectDto>
    {
        public CreateKindOfSubjectDtoValidator()
        {
            Include(new IKindOfSubjectDtoValidator());
        }
    }
}
