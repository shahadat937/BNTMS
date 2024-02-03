using MediatR;

namespace SchoolManagement.Application.Features.Occupations.Requests.Commands
{
    public class DeleteOccupationCommand : IRequest
    {
        public int OccupationId { get; set; }
    }
}
