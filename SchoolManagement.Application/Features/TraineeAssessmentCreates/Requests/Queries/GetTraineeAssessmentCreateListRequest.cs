using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeAssessmentCreate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeAssessmentCreates.Requests.Queries
{
    public class GetTraineeAssessmentCreateListRequest : IRequest<PagedResult<TraineeAssessmentCreateDto>>
    {
        public QueryParams QueryParams { get; set; } 
        public int CourseDurationId { get; set; }
        public int BaseSchoolNameId { get; set; }
    }
}
