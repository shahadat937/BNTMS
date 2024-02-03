using SchoolManagement.Application.DTOs.GrandFatherType;
using MediatR;

namespace SchoolManagement.Application.Features.GrandFatherTypes.Requests.Queries
{
    public class GetGrandFatherTypeDetailRequest : IRequest<GrandFatherTypeDto>
    {
        public int GrandfatherTypeId { get; set; }
    }
}
