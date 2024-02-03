using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeAssessmentCreate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Queries
{
    public class GetTraineeAssessmentCreateDetailRequest : IRequest<TraineeAssessmentCreateDto>
    {
        public int TraineeAssessmentCreateId { get; set; }
    }
}
