using FluentValidation;

namespace SchoolManagement.Application.DTOs.FamilyInfo.Validators
{
   public class CreateFamilyInfoDtoValidator: AbstractValidator<CreateFamilyInfoDto>
    {
        public CreateFamilyInfoDtoValidator()
        {
            Include(new IFamilyInfoDtoValidator());
        }
    }
}
