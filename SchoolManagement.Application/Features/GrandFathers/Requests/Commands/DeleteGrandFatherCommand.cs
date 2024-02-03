using MediatR;

namespace SchoolManagement.Application.Features.GrandFathers.Requests.Commands
{
    public class DeleteGrandFatherCommand : IRequest
    {
        public int GrandFatherId { get; set; }
    }
}
