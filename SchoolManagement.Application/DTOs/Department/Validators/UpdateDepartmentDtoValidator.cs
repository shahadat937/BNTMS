using FluentValidation;

namespace SchoolManagement.Application.DTOs.Department.Validators
{
    public class UpdateDepartmentDtoValidator : AbstractValidator<DepartmentDto>
    {
        public UpdateDepartmentDtoValidator()
        {
            Include(new IDepartmentDtoValidator());

            RuleFor(p => p.DepartmentId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
