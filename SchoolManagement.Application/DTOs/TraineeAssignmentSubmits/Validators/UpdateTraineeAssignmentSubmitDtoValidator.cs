using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineeAssignmentSubmits.Validators
{
    public class UpdateTraineeAssignmentSubmitDtoValidator : AbstractValidator<TraineeAssignmentSubmitDto>
    {
        public UpdateTraineeAssignmentSubmitDtoValidator()
        { 
            //Include(new ITraineeAssignmentSubmitDtoValidator());

            //RuleFor(c => c.TraineeAssignmentSubmitName).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
