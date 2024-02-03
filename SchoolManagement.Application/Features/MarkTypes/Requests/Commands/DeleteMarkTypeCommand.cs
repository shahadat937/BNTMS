using MediatR;

namespace SchoolManagement.Application.Features.MarkTypes.Requests.Commands
{
    public class DeleteMarkTypeCommand : IRequest
    {
        public int Id { get; set; } 
    }
}
