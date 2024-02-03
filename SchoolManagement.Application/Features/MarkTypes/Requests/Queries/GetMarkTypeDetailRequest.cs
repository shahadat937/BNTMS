using MediatR;
using SchoolManagement.Application.DTOs.MarkType;

namespace SchoolManagement.Application.Features.MarkTypes.Requests.Queries
{
    public class GetMarkTypeDetailRequest : IRequest<MarkTypeDto>
    {
        public int Id { get; set; }
    }
}
