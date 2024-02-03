using MediatR;

namespace SchoolManagement.Application.Features.IndividualBulletins.Requests.Commands
{
    public class DeleteIndividualBulletinCommand : IRequest
    {
        public int IndividualBulletinId { get; set; }
    }
}
 