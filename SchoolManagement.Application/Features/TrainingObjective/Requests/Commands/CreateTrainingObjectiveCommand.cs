using MediatR;
using SchoolManagement.Application.DTOs.TrainingObjective;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingObjectives.Requests.Commands
{
    public class CreateTrainingObjectiveCommand : IRequest<BaseCommandResponse>
    {
        public CreateTrainingObjectiveDto TrainingObjectiveDto { get; set; }
    }
}
