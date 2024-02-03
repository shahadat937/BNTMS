using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.WithdrawnDocs.Requests.Queries
{
    public class GetSelectedWithdrawnDocRequest : IRequest<List<SelectedModel>>
    {
    }
}
    