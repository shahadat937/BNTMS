using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.GrandFatherTypes.Requests.Queries
{
    public class GetSelectedGrandFatherTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
