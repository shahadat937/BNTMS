using FluentValidation;


namespace SchoolManagement.Application.DTOs.MaritalStatus.Validators
{
    public class UpdateMaritalStatusDtoValidator : AbstractValidator<MaritalStatusDto>
    {
        public UpdateMaritalStatusDtoValidator() 
        {
            Include(new IMaritalStatusDtoValidator());

            RuleFor(p => p.MaritalStatusId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}