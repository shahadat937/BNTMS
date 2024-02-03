using SchoolManagement.Application.DTOs.RelationType;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.RelationTypes.Requests.Commands
{
    public class CreateRelationTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateRelationTypeDto RelationTypeDto { get; set; }

    }
}
