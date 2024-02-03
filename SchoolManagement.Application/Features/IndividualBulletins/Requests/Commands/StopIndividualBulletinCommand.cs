using MediatR;

namespace SchoolManagement.Application.Features.IndividualBulletins.Requests.Commands
{
    public class StopIndividualBulletinCommand : IRequest
    {
        public int IndividualBulletinId { get; set; }  
    }
}
