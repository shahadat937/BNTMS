using FluentValidation;
using SchoolManagement.Application.DTOs.BnaSubjectname.Validators;

namespace SchoolManagement.Application.DTOs.BnaSubjectName.Validators
{
    public class UpdateBnaSubjectNameDtoValidator : AbstractValidator<BnaSubjectNameDto>
    {
        public UpdateBnaSubjectNameDtoValidator()
        {
            Include(new IBnaSubjectNameDtoValidator()); 

            RuleFor(p => p.BnaSubjectNameId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
