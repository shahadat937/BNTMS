using SchoolManagement.Application.DTOs.TraineeAssessmentCreate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Commands
{
    public class UpdateTraineeAssessmentCreateCommand : IRequest<Unit>
    {
        public TraineeAssessmentCreateDto TraineeAssessmentCreateDto { get; set; }

    }
}
