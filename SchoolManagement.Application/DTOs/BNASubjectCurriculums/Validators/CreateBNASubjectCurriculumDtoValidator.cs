using FluentValidation;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculums;
using SchoolManagement.Application.DTOs.BnaSubjectCurriculums.Validators;

namespace SchoolManagement.Application.DTOs.BnaSubjectCurriculum.Validators
{
    public class CreateBnaSubjectCurriculumDtoValidator : AbstractValidator<CreateBnaSubjectCurriculumDto>
    {
        public CreateBnaSubjectCurriculumDtoValidator()
        {
            Include(new IBnaSubjectCurriculumDtoValidator());
        }
    }
}
