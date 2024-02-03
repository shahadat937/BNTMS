using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.RelationType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.RelationTypes.Requests.Queries
{
    public class GetRelationTypeDetailRequest : IRequest<RelationTypeDto>
    {
        public int RelationTypeId { get; set; }
    }
}
