using SchoolManagement.Application.DTOs.ParentRelative;
using MediatR;

namespace SchoolManagement.Application.Features.ParentRelatives.Requests.Queries
{
    public class GetParentRelativeDetailRequest : IRequest<ParentRelativeDto>
    {
        public int ParentRelativeId { get; set; }
    }
}
