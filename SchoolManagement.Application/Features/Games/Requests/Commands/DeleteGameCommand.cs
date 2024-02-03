using MediatR;

namespace SchoolManagement.Application.Features.Games.Requests.Commands
{
    public class DeleteGameCommand : IRequest  
    {  
        public int Id { get; set; }
    }
}
