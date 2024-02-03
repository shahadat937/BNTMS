using MediatR;
using SchoolManagement.Application.DTOs.Bulletin;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Queries
{
    public class GetBulletinDetailRequest : IRequest<BulletinDto>
    {
        public int BulletinId { get; set; }
    }
}
 