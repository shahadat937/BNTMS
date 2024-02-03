using MediatR;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Commands
{
    public class ChangeBulletinStatusCommand : IRequest
    {
        public int BulletinId { get; set; }
        public int Status { get; set; }
    }
}
