using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MarkCategorys.Requests.Queries
{
    public class GetSelectedMarkCategoryRequest : IRequest<List<SelectedModel>>
    {
    }
}
