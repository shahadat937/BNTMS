using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeAssessmentMark;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Queries
{
    public class GetTraineeAssessmentMarkDetailRequest : IRequest<TraineeAssessmentMarkDto>
    {
        public int TraineeAssessmentMarkId { get; set; }
    }
}
