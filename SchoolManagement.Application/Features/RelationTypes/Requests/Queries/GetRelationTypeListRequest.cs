using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.RelationType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.RelationTypes.Requests.Queries
{
    public class GetRelationTypeListRequest : IRequest<PagedResult<RelationTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
