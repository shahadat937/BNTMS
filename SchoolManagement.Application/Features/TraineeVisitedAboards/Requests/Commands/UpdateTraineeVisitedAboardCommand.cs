using SchoolManagement.Application.DTOs.TraineeVisitedAboard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Commands
{
    public class UpdateTraineeVisitedAboardCommand : IRequest<Unit>
    {
        public TraineeVisitedAboardDto TraineeVisitedAboardDto { get; set; }

    }
}
