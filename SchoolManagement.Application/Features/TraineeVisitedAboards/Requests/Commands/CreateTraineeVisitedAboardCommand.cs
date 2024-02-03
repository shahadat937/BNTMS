using SchoolManagement.Application.DTOs.TraineeVisitedAboard;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Commands
{
    public class CreateTraineeVisitedAboardCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeVisitedAboardDto TraineeVisitedAboardDto { get; set; }

    }
}
