using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.Occupations.Requests.Queries
{
    public class GetSelectedOccupationRequest : IRequest<List<SelectedModel>>
    {
    }
}
