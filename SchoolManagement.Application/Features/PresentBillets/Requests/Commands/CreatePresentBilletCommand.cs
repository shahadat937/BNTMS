using SchoolManagement.Application.DTOs.PresentBillet;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.PresentBillets.Requests.Commands
{
    public class CreatePresentBilletCommand : IRequest<BaseCommandResponse>
    {
        public CreatePresentBilletDto PresentBilletDto { get; set; }

    }
}
