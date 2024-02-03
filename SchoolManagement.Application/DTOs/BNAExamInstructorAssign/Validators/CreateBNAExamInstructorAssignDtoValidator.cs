using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaExamInstructorAssign.Validators
{ 
    public class CreateBnaExamInstructorAssignDtoValidator : AbstractValidator<CreateBnaExamInstructorAssignDto>
    {
        public CreateBnaExamInstructorAssignDtoValidator()
        {
            Include(new IBnaExamInstructorAssignDtoValidator());
        }
    }
}
 