using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeVisitedAboard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Queries
{
    public class GetTraineeVisitedAboardDetailRequest : IRequest<TraineeVisitedAboardDto>
    {
        public int TraineeVisitedAboardId { get; set; }
    }
}
