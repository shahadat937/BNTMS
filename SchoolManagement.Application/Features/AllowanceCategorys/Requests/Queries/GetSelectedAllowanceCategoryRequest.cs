using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Requests.Queries
{
    public class GetSelectedAllowanceCategoryRequest : IRequest<List<SelectedModel>>
    {
       // public int AllowanceCategoryId { get; set; }
    }
}  
  