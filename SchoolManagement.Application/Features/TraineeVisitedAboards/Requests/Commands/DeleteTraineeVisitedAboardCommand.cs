using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Commands
{
    public class DeleteTraineeVisitedAboardCommand : IRequest
    {
        public int TraineeVisitedAboardId { get; set; }
    }
}
