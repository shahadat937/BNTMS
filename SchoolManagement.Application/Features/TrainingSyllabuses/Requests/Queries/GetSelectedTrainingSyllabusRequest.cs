using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Queries
{
    public class GetSelectedTrainingSyllabusRequest : IRequest<List<SelectedModel>>
    {
    }
}
