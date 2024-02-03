using MediatR;
using SchoolManagement.Application.DTOs.TrainingSyllabus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Commands
{
    public class UpdateTrainingSyllabusCommand : IRequest<Unit>
    {
        public TrainingSyllabusDto TrainingSyllabusDto { get; set; }
    }
}
