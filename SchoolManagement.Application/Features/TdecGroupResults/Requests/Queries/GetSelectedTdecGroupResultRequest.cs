using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TdecGroupResults.Requests.Queries
{
    public class GetSelectedTdecGroupResultRequest : IRequest<List<SelectedModel>>
    {
    }
}
