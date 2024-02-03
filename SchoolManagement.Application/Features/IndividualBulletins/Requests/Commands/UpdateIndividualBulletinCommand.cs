using MediatR;
using SchoolManagement.Application.DTOs.IndividualBulletin;

namespace SchoolManagement.Application.Features.IndividualBulletins.Requests.Commands
{
    public class UpdateIndividualBulletinCommand : IRequest<Unit>
    {
        public IndividualBulletinDto IndividualBulletinDto { get; set; }
    }
} 
