using FluentValidation;


namespace SchoolManagement.Application.DTOs.MarkType.Validators
{
    public class UpdateMarkTypeDtoValidator : AbstractValidator<MarkTypeDto>
    {
        public UpdateMarkTypeDtoValidator() 
        {
            Include(new IMarkTypeDtoValidator());

            RuleFor(p => p.MarkTypeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}