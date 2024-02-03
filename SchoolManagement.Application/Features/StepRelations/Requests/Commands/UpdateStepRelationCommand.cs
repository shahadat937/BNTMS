using SchoolManagement.Application.DTOs.StepRelation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.StepRelations.Requests.Commands
{
    public class UpdateStepRelationCommand : IRequest<Unit>
    {
        public StepRelationDto StepRelationDto { get; set; }

    }
}
