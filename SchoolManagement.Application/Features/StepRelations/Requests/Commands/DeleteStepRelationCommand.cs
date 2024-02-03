using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.StepRelations.Requests.Commands
{
    public class DeleteStepRelationCommand : IRequest
    {
        public int StepRelationId { get; set; }
    }
}
