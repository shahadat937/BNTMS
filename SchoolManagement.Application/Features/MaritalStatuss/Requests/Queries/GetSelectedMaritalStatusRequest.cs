using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.MaritalStatuss.Requests.Queries
{
    public class GetSelectedMaritalStatusRequest : IRequest<List<SelectedModel>>
    {
    }
}
