﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TrainingSyllabus.Validators
{
    public class ITrainingSyllabusDtoValidator : AbstractValidator<ITrainingSyllabusDto>
    {
        public ITrainingSyllabusDtoValidator()
        {
            //RuleFor(c => c.Name)
            //   .NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
        
    }
}
