using MediatR;
using SchoolManagement.Application.DTOs.TrainingSyllabus;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Commands
{
    public class CreateTrainingSyllabusCommand : IRequest<BaseCommandResponse>
    {
        public CreateTrainingSyllabusDto TrainingSyllabusDto { get; set; }
    }
}
