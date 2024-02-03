using MediatR;
using SchoolManagement.Application.DTOs.AllowancePercentage;

namespace SchoolManagement.Application.Features.AllowancePercentages.Requests.Queries
{
    public class GetAllowancePercentageDetailRequest : IRequest<AllowancePercentageDto>
    {
        public int AllowancePercentageId { get; set; }
    }
}
 