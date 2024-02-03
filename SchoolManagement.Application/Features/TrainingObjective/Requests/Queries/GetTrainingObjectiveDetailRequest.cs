using MediatR;
using SchoolManagement.Application.DTOs.TrainingObjective;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingObjectives.Requests.Queries
{
    public class GetTrainingObjectiveDetailRequest : IRequest<TrainingObjectiveDto>
    {
        public int TrainingObjectiveId { get; set; }
    }
}
