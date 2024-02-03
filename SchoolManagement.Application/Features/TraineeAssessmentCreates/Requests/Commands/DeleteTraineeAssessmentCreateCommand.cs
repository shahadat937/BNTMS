using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Commands
{
    public class DeleteTraineeAssessmentCreateCommand : IRequest
    {
        public int TraineeAssessmentCreateId { get; set; }
    }
}
