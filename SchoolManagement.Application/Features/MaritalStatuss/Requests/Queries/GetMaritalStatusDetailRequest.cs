using MediatR;
using SchoolManagement.Application.DTOs.MaritalStatus;

namespace SchoolManagement.Application.Features.MaritalStatuss.Requests.Queries
{
    public class GetMaritalStatusDetailRequest : IRequest<MaritalStatusDto>
    {
        public int Id { get; set; }
    }
}
