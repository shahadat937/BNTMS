using SchoolManagement.Application.DTOs.TraineeAssessmentMark;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Commands
{
    public class UpdateTraineeAssessmentMarkCommand : IRequest<Unit>
    {
        public TraineeAssessmentMarkDto TraineeAssessmentMarkDto { get; set; }

    }
}
