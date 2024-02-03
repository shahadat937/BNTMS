using SchoolManagement.Application.DTOs.GrandFather;
using MediatR;

namespace SchoolManagement.Application.Features.GrandFathers.Requests.Queries
{
    public class GetGrandFatherDetailRequest : IRequest<GrandFatherDto>
    {
        public int GrandFatherId { get; set; }
    }
}
