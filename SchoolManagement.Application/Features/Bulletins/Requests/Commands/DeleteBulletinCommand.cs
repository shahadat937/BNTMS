using MediatR;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Commands
{
    public class DeleteBulletinCommand : IRequest
    {
        public int BulletinId { get; set; }
    }
}
 