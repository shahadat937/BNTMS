using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineePicture.Validators
{
    public class UpdateTraineePictureDtoValidator : AbstractValidator<TraineePictureDto>
    {
        public UpdateTraineePictureDtoValidator() 
        {
            Include(new ITraineePictureDtoValidator());

            //RuleFor(p => p.BnaBatchId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaSemesterDurationId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.BnaSemesterDurationId).NotNull().WithMessage("{PropertyName} must be present");
            //RuleFor(p => p.TraineeId).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
