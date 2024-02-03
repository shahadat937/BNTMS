using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BnaSubjectCurriculums.Validators
{
    public class UpdateBnaSubjectCurriculumDtoValidator : AbstractValidator<BnaSubjectCurriculumDto>
    {
        public UpdateBnaSubjectCurriculumDtoValidator()
        {
            Include(new IBnaSubjectCurriculumDtoValidator());

            RuleFor(b => b.BnaSubjectCurriculumId).NotNull().WithMessage("{Propertyname} must be present");
        }
    }
}
 