using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.StepRelation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.StepRelations.Requests.Queries
{
    public class GetStepRelationDetailRequest : IRequest<StepRelationDto>
    {
        public int StepRelationId { get; set; }
    }
}
