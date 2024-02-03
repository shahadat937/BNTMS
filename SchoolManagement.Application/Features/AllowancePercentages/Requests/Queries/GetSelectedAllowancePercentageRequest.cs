using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AllowancePercentages.Requests.Queries
{
    public class GetSelectedAllowancePercentageRequest : IRequest<List<SelectedModel>>
    {
    }
}  
  