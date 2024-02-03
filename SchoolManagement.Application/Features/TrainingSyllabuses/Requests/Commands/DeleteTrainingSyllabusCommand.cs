using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Commands
{
    public class DeleteTrainingSyllabusCommand : IRequest
    {
        public int TrainingSyllabusId { get; set; }
    }
}
