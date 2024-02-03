using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingObjectives.Requests.Commands
{
    public class DeleteTrainingObjectiveCommand : IRequest
    {
        public int TrainingObjectiveId { get; set; }
    }
}
