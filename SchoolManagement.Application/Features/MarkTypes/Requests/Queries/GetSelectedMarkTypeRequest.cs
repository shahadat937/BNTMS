using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MarkTypes.Requests.Queries
{
    public class GetSelectedMarkTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
