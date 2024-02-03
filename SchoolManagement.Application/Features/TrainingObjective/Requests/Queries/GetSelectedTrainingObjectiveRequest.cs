using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingObjectives.Requests.Queries
{
    public class GetSelectedTrainingObjectiveRequest : IRequest<List<SelectedModel>>
    {
    }
}
