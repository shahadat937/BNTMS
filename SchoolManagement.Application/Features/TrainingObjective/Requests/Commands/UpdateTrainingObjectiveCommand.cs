using MediatR;
using SchoolManagement.Application.DTOs.TrainingObjective;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingObjectives.Requests.Commands
{
    public class UpdateTrainingObjectiveCommand : IRequest<Unit>
    {
        public TrainingObjectiveDto TrainingObjectiveDto { get; set; }
    }
}
