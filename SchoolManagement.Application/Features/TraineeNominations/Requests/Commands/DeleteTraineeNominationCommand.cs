using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Commands
{
    public class DeleteTraineeNominationCommand : IRequest
    {
        public int TraineeNominationId { get; set; }
    }
}
