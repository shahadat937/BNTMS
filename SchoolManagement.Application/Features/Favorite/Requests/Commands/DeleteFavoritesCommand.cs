using MediatR;

namespace SchoolManagement.Application.Features.Favorite.Requests.Commands
{
    public class DeleteFavoritesCommand : IRequest   
    {  
        public int Id { get; set; }
    }
}
