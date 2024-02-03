using FluentValidation;

namespace SchoolManagement.Application.DTOs.TraineePicture.Validators
{
    public class CreateTraineePictureDtoValidator : AbstractValidator<CreateTraineePictureDto>
    {
        public CreateTraineePictureDtoValidator()
        {
            Include(new ITraineePictureDtoValidator());
        }
    }
}
