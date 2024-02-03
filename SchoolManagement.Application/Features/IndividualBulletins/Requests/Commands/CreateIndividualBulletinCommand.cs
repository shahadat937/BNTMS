using MediatR;
using SchoolManagement.Application.DTOs.IndividualBulletins;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.IndividualBulletins.Requests.Commands
{
    public class CreateIndividualBulletinCommand : IRequest<BaseCommandResponse>
    {
        public CreateIndividualBulletinListDto IndividualBulletinDto { get; set; }
    }
}
 