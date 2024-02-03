using SchoolManagement.Application.DTOs.TraineeVisitedAboard;
using MediatR;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Queries
{
    public class GetTraineeVisitedAboardListByTraineeRequest : IRequest<List<TraineeVisitedAboardDto>>
    {
        public int Traineeid { get; set; }
    }
}
