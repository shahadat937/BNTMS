using MediatR;
using SchoolManagement.Application.DTOs.TrainingSyllabus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Queries
{
    public class GetTrainingSyllabusDetailRequest : IRequest<TrainingSyllabusDto>
    {
        public int TrainingSyllabusId { get; set; }
    }
}
