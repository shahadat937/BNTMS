using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Commands
{
    public class DeleteTraineeAssessmentMarkCommand : IRequest
    {
        public int TraineeAssessmentMarkId { get; set; }
    }
}
