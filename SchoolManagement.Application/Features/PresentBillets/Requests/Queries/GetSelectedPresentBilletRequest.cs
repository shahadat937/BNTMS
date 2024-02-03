using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.PresentBillets.Requests.Queries
{
    public class GetSelectedPresentBilletRequest : IRequest<List<SelectedModel>>
    {
    }
}
 