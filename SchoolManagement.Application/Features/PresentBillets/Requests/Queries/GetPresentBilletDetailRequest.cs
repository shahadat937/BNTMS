using SchoolManagement.Application.DTOs.PresentBillet;
using MediatR;

namespace SchoolManagement.Application.Features.PresentBillets.Requests.Queries
{
    public class GetPresentBilletDetailRequest : IRequest<PresentBilletDto>
    {
        public int PresentBilletId { get; set; }
    }
}
