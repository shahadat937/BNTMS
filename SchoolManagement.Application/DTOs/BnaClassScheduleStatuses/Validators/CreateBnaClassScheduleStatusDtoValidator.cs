using FluentValidation;

namespace SchoolManagement.Application.DTOs.BnaClassScheduleStatuses.Validators
{ 
    public class CreateBnaClassScheduleStatusDtoValidator : AbstractValidator<CreateBnaClassScheduleStatusDto>
    {
        public CreateBnaClassScheduleStatusDtoValidator()  
        {
            Include(new IBnaClassScheduleStatusDtoValidator()); 
        }
    }
}
 