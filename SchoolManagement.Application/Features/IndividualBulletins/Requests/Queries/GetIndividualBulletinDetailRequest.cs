using MediatR;
using SchoolManagement.Application.DTOs.IndividualBulletin;

namespace SchoolManagement.Application.Features.IndividualBulletins.Requests.Queries
{
    public class GetIndividualBulletinDetailRequest : IRequest<IndividualBulletinDto>
    {
        public int IndividualBulletinId { get; set; }
    }
}
 