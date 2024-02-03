using SchoolManagement.Application.DTOs.TraineeAssessmentCreate;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Commands
{
    public class CreateTraineeAssessmentCreateCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeAssessmentCreateDto TraineeAssessmentCreateDto { get; set; }

    }
}
