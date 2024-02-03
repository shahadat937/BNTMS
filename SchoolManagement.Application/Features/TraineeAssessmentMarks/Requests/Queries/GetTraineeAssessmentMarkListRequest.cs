using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeAssessmentMark;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Queries
{
    public class GetTraineeAssessmentMarkListRequest : IRequest<PagedResult<TraineeAssessmentMarkDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
