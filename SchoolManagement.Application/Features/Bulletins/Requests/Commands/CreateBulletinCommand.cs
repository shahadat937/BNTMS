using MediatR;
using SchoolManagement.Application.DTOs.Bulletin;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Commands
{
    public class CreateBulletinCommand : IRequest<BaseCommandResponse>
    {
        public CreateBulletinDto BulletinDto { get; set; }
    }
}
 