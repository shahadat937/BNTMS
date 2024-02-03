using SchoolManagement.Application.DTOs.PresentBillet;
using MediatR;

namespace SchoolManagement.Application.Features.PresentBillets.Requests.Commands
{
    public class UpdatePresentBilletCommand : IRequest<Unit>
    {
        public PresentBilletDto PresentBilletDto { get; set; }

    }
}
