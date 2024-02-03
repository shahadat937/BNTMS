
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TrainingSyllabus.Validators
{
   public class CreateTrainingSyllabusDtoValidator : AbstractValidator<CreateTrainingSyllabusDto>
    {
        public CreateTrainingSyllabusDtoValidator()
        {
            Include(new ITrainingSyllabusDtoValidator());
        }
    }
}
