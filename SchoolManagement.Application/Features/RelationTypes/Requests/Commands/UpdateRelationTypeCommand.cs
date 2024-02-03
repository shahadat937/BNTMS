using SchoolManagement.Application.DTOs.RelationType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.RelationTypes.Requests.Commands
{
    public class UpdateRelationTypeCommand : IRequest<Unit>
    {
        public RelationTypeDto RelationTypeDto { get; set; }

    }
}
