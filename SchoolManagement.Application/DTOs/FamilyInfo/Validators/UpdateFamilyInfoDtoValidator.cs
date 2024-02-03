using FluentValidation;

namespace SchoolManagement.Application.DTOs.FamilyInfo.Validators
{
    public class UpdateFamilyInfoDtoValidator: AbstractValidator<FamilyInfoDto>
    {
        public UpdateFamilyInfoDtoValidator()
        {
            Include(new IFamilyInfoDtoValidator());

            //RuleFor(c => c.FamilyInfoId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
