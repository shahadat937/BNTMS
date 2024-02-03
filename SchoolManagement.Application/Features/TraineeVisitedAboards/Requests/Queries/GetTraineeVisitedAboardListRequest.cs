using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeVisitedAboard;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Queries
{
    public class GetTraineeVisitedAboardListRequest : IRequest<PagedResult<TraineeVisitedAboardDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
