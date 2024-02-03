using SchoolManagement.Application.DTOs.StepRelation;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.StepRelations.Requests.Commands
{
    public class CreateStepRelationCommand : IRequest<BaseCommandResponse>
    {
        public CreateStepRelationDto StepRelationDto { get; set; }

    }
}
