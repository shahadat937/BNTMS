using MediatR;
using SchoolManagement.Application.DTOs.Bulletin;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Commands
{
    public class UpdateBulletinCommand : IRequest<Unit>
    {
        public BulletinDto BulletinDto { get; set; }
    }
} 
