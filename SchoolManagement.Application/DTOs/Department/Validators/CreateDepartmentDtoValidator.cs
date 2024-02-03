using FluentValidation;

namespace SchoolManagement.Application.DTOs.Department.Validators
{
    public class CreateDepartmentDtoValidator : AbstractValidator<CreateDepartmentDto>
    {
        public CreateDepartmentDtoValidator()
        {
            Include(new IDepartmentDtoValidator());
        }
    }
}
