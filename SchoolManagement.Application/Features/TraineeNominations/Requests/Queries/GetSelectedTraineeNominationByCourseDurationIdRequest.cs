using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetSelectedTraineeNominationByCourseDurationIdRequest : IRequest<List<SelectedModel>>
    {
        public int CourseDurationId { get; set; }
    } 
} 
    