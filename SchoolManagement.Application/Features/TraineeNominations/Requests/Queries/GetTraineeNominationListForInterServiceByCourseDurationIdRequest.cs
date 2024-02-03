using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeNomination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetTraineeNominationListForInterServiceByCourseDurationIdRequest : IRequest<List<TraineeNominationDto>>
    {
        //public QueryParams QueryParams { get; set; }
        public int CourseDurationId { get; set; }
    } 
}
