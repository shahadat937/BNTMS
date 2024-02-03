using SchoolManagement.Application.DTOs.TraineeNomination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Commands
{
    public class UpdateTraineeNominationCommand : IRequest<Unit>
    {
        public TraineeNominationDto TraineeNominationDto { get; set; }

    }
}
