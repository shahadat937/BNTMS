using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.StepRelation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.StepRelations.Requests.Queries
{
    public class GetStepRelationListRequest : IRequest<PagedResult<StepRelationDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
