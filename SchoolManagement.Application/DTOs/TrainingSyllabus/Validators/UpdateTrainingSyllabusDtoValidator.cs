using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TrainingSyllabus.Validators
{
    public class UpdateTrainingSyllabusDtoValidator : AbstractValidator<TrainingSyllabusDto>
    {
        public UpdateTrainingSyllabusDtoValidator()
        {
            Include(new ITrainingSyllabusDtoValidator());

            //RuleFor(c => c.Name).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
