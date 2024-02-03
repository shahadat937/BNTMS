using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Queries
{
    public class GetSelectedBnaClassTestTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
  