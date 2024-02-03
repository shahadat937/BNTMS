using SchoolManagement.Application.DTOs.TraineeAssessmentMark;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Commands
{
    public class CreateTraineeAssessmentMarkCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeAssessmentMarkDto TraineeAssessmentMarkDto { get; set; }

    }
}
