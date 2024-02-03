using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.RelationTypes.Requests.Commands
{
    public class DeleteRelationTypeCommand : IRequest
    {
        public int RelationTypeId { get; set; }
    }
}
