using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Queries
{
    public class GetSelectedTraineeAssessmentCreateRequest : IRequest<List<SelectedModel>>
    {
        public int CourseDurationId { get; set; }
    }
}
  