using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeNomination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetTraineeNominationDetailByCourseDurationIdRequest : IRequest<TraineeNominationDto>
    {
        public int TraineeNominationId { get; set; }
        public int CourseDurationId { get; set; }
    }
}
 