using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.RelationTypes.Requests.Queries
{
    public class GetSelectedRelationTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
