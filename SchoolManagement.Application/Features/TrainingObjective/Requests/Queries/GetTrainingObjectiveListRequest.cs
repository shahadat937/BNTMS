using MediatR;
using SchoolManagement.Application.DTOs.TrainingObjective;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingObjectives.Requests.Queries
{
   public class GetTrainingObjectiveListRequest : IRequest<PagedResult<TrainingObjectiveDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
